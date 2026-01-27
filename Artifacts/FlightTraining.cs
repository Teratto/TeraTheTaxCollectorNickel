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
public class FlightTraining : Artifact, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "FLightTraining", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "FlightTraining", "desc"]).Localize,
            /*
             * For Artifacts with just one sprite, registering them at the place of usage helps simplify things.
             */
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/FlightTraining.png")).Sprite
        });
    }

    /*
     * Unlike Cards, Artifacts have no required methods. Implement the ones you need, and leave the rest unimplemented.
     * By default, Artifacts have everything implemented with methods that do nothing, so there is no need to call the super.
     */
    private int currentTurn;
    public override void OnTurnStart(State state, Combat combat)
    {
        currentTurn++;
        if (currentTurn >= 3)
        {
            combat.QueueImmediate(new AStatus()
            {
                statusAmount = 1,
                status = Status.evade,
                targetPlayer = true
            });
            currentTurn = 0;
        }
    }
    public override int? GetDisplayNumber(State s)
    {
        return currentTurn;
    }
}