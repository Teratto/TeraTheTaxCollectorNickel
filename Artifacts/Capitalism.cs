using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using TeraTaxMod.Cards;

namespace TeraTaxMod.Artifacts;

/*
 * Artifacts are a nice way to accentuate a character's potential.
 * They can be simple effects that occur at simple times, they can modify an existing mechanic or one introduced by the character.
 * Similarly to cards, ensure you add this type to your ModEntry for registration.
 */
public class Capitalism : Artifact, IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Boss],
                owner = ModEntry.Instance.TeraTaxDeck.Deck
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Capitalism", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Capitalism", "desc"]).Localize,
            /*
             * For Artifacts with just one sprite, registering them at the place of usage helps simplify things.
             */
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Capitalism.png")).Sprite
        });
    }

    /*
     * Unlike Cards, Artifacts have no required methods. Implement the ones you need, and leave the rest unimplemented.
     * By default, Artifacts have everything implemented with methods that do nothing, so there is no need to call the super.
     */
    public override void OnReceiveArtifact(State s)
	{
		base.OnReceiveArtifact(s);
		s.ship.baseEnergy++;
	}
    
    public override void OnTurnEnd(State s, Combat c)
    {
        base.OnTurnEnd(s, c);
        int playerTax = s.ship.Get(ModEntry.Instance.TeraTaxationStatus.Status);
        if (playerTax < 3)
            {
                c.QueueImmediate(new AStatus()
                {
                    status = ModEntry.Instance.TeraTaxationStatus.Status,
                    statusAmount = 1,
                    targetPlayer = true,
                    artifactPulse = Key()
                });
            }
        
    }
    public override List<Tooltip> GetExtraTooltips()
         => [
             .. StatusMeta.GetTooltips(ModEntry.Instance.TeraTaxationStatus.Status, 1),
         ];
}