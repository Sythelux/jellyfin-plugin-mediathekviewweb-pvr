using System;

namespace CakeBuild;

public class Build
{
    public string Name { get; set; }
    public Guid Guid { get; set; }
    public string Version { get; set; }
    public string TargetAbi { get; set; }
    public string Framework { get; set; }
    public string Overview { get; set; }
    public string Description { get; set; }
    public string Owner { get; set; }
    public string[] Artifacts { get; set; }
    public string Changelog { get; set; }
    public string Category { get; set; }
}
