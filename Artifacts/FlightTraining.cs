using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "FlightTraining", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "FlightTraining", "desc"]).Localize,
            /*
             * For Artifacts with just one sprite, registering them at the place of usage helps simplify things.
             */
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/FlightTraining.png")).Sprite
        });
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(AStatus), nameof(AStatus.Begin)),
            postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(FlightTraining_Postfix))
            );

    }
    public override int? GetDisplayNumber(State s)
    {
        return badAmount;
    }


    public int badAmount = 0;
    public static void FlightTraining_Postfix(AStatus __instance, State s, Combat c)
    {
        bool isItGood = DB.statuses[__instance.status].isGood;
        Ship currentShip = __instance.targetPlayer ? s.ship : c.otherShip;

        if (s.EnumerateAllArtifacts().FirstOrDefault(a => a is FlightTraining) is not { } artifact)
            return;

        var flightTrainingArti = (FlightTraining)artifact;

        if (isItGood == false && __instance.statusAmount > 0 && currentShip == s.ship) 
        {
            flightTrainingArti.badAmount += 1;
        }
        if (flightTrainingArti.badAmount >= 2)
        {
            c.QueueImmediate(new AStatus()
            {
                statusAmount = 1,
                status = Status.evade,
                targetPlayer = true
            });
            flightTrainingArti.badAmount = 0;
        }
       
    }

}