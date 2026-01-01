using Microsoft.Extensions.Logging;
using SwiftlyS2.Shared;
using SwiftlyS2.Shared.GameEventDefinitions;
using SwiftlyS2.Shared.GameEvents;
using SwiftlyS2.Shared.Misc;
using SwiftlyS2.Shared.Plugins;

namespace CS2_RemoveMapWeapons;

[PluginMetadata(Id = "CS2_RemoveMapWeapons", Version = "1.0.0", Name = "CS2 Remove Map Weapons", Author = "BenGorr", Description = "Remove spawned weapon from the maps on round start.")]
public partial class CS2_RemoveMapWeapons : BasePlugin {
    
    public CS2_RemoveMapWeapons(ISwiftlyCore core) : base(core)
    {
    }

    public override void ConfigureSharedInterface(IInterfaceManager interfaceManager) {
    }

    public override void UseSharedInterface(IInterfaceManager interfaceManager) {
    }

    public override void Load(bool hotReload) {
    
    }

    public override void Unload() {
    }

    private void RemoveMapWeapons()
    {
        var entities = Core.EntitySystem.GetAllEntities().ToList();
        foreach (var entity in entities)
        {
            if (entity == null || entity.IsValid == false) continue;
            if (!entity.DesignerName.StartsWith("weapon_")) continue;

            entity.Despawn();
        }
    }

    [GameEventHandler(HookMode.Post)]
    private HookResult OnRoundStartPreEntity(EventRoundStart @event)
    {
        if (@event == null)
            return HookResult.Continue;

        RemoveMapWeapons();

        return HookResult.Continue;
    }
} 