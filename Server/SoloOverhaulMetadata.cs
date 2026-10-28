using SPTarkov.Server.Core.Models.Spt.Mod;

namespace SoloOverhaul
{
    public record SoloOverhaulMetadata : IModMetadata
    {
        public string ModGuid { get; init; } = "com.lunarworld.solooverhaul";
        public string Name { get; init; } = "SoloOverhaul";
        public string Author { get; init; } = "LunarWorld";
        public List<string>? Contributors { get; init; }
        public SemanticVersioning.Version Version { get; init; } = new("0.0.1");
        public SemanticVersioning.Range SptVersion { get; init; } = new("~4.1.0");
        public List<string>? Incompatibilities { get; init; }
        public Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }
        public string? Url { get; init; }
        public string License { get; init; } = "CC BY-NC-SA 4.0";
        public bool HasPrepatcher { get; init; } = false;
    }
}
