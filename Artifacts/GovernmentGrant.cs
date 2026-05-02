using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using TeraTaxMod.Cards;
using TeraTaxMod.Features;

namespace TeraTaxMod.Artifacts;

public class GovernmentGrant : Artifact, IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Common],
                owner = ModEntry.Instance.TeraTaxDeck.Deck
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "GovernmentGrant", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "GovernmentGrant", "desc"]).Localize,
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Grant.png")).Sprite
        });
    }

    public override void OnCombatStart(State state, Combat combat)
    {
        combat.Queue(new AStatus()
        {
            status = ModEntry.Instance.TeraBailoutStatus.Status,
            statusAmount = 1,
            targetPlayer = true,
            artifactPulse = Key() 
        });
    }
    public override List<Tooltip> GetExtraTooltips()
         => [
             .. StatusMeta.GetTooltips(ModEntry.Instance.TeraTaxationStatus.Status, 1),
             .. StatusMeta.GetTooltips(ModEntry.Instance.TeraBailoutStatus.Status, 2),
         ];
}