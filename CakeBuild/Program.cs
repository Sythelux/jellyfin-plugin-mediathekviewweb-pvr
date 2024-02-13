using System;
using System.IO;
using Cake.Common;
using Cake.Common.IO;
using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Clean;
using Cake.Common.Tools.DotNet.Publish;
using Cake.Core;
using Cake.Frosting;
using Cake.Yaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YamlDotNet.Serialization.NamingConventions;

namespace CakeBuild;

public static class Program
{
    public static int Main(string[] args)
    {
        return new CakeHost()
            .UseContext<BuildContext>()
            .Run(args);
    }
}

public class BuildContext : FrostingContext
{
    public const string ProjectName = "Jellyfin.Plugin.MediathekViewWeb.PVR";
    public string BuildConfiguration { get; }
    public string Version { get; }
    public string TargetAbi { get; }
    public string Name { get; }
    public bool SkipJsonValidation { get; }

    public BuildContext(ICakeContext context) : base(context)
    {
        BuildConfiguration = context.Argument("configuration", "Release");
        SkipJsonValidation = context.Argument("skipJsonValidation", false);
        var pluginBuildInfo = context.DeserializeYamlFromFile<Build>($"../build.yaml", new DeserializeYamlSettings { NamingConvention = CamelCaseNamingConvention.Instance });
        Version = pluginBuildInfo.Version;
        TargetAbi = pluginBuildInfo.TargetAbi;
        Name = pluginBuildInfo.Name;
    }
}

[TaskName("ValidateJson")]
public sealed class ValidateJsonTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        if (context.SkipJsonValidation)
        {
            return;
        }

        var jsonFiles = context.GetFiles($"../{BuildContext.ProjectName}/assets/**/*.json");
        foreach (var file in jsonFiles)
        {
            try
            {
                var json = File.ReadAllText(file.FullPath);
                JToken.Parse(json);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Validation failed for JSON file: {file.FullPath}{Environment.NewLine}{ex.Message}", ex);
            }
        }
    }
}

[TaskName("Build")]
[IsDependentOn(typeof(ValidateJsonTask))]
public sealed class BuildTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.DotNetClean($"../{BuildContext.ProjectName}/{BuildContext.ProjectName}.csproj",
            new DotNetCleanSettings { Configuration = context.BuildConfiguration });


        context.DotNetPublish($"../{BuildContext.ProjectName}/{BuildContext.ProjectName}.csproj",
            new DotNetPublishSettings { Configuration = context.BuildConfiguration });
    }
}

[TaskName("Package")]
[IsDependentOn(typeof(BuildTask))]
public sealed class PackageTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.EnsureDirectoryExists("../Releases");
        context.EnsureDirectoryExists($"../Releases/{BuildContext.ProjectName}");
        context.CleanDirectory($"../Releases/{BuildContext.ProjectName}");
        var baseBinPath = $"../{BuildContext.ProjectName}/bin/{context.BuildConfiguration}/Plugins/{BuildContext.ProjectName}";
        var targetDirectoryPath = $"../Releases/{BuildContext.ProjectName}/";
        context.CopyFiles($"{baseBinPath}/{BuildContext.ProjectName}.*", targetDirectoryPath);
        if (context.DirectoryExists($"{baseBinPath}/assets"))
        {
            context.CopyDirectory($"{baseBinPath}/assets", $"{targetDirectoryPath}/assets");
        }

        // context.CopyFile($"{baseBinPath}/modinfo.json", $"{targetDirectoryPath}/modinfo.json");
        if (context.FileExists($"../{BuildContext.ProjectName}/logo.png"))
        {
            context.CopyFile($"../{BuildContext.ProjectName}/logo.png", $"{targetDirectoryPath}/logo.png");
        }

        if (context.BuildConfiguration == "Release")
        {
            context.Zip($"{targetDirectoryPath}", $"../Releases/{BuildContext.ProjectName}-v{context.Version}-{context.TargetAbi}.zip");
        }
    }
}

[TaskName("Default")]
[IsDependentOn(typeof(PackageTask))]
public class DefaultTask : FrostingTask
{
}
