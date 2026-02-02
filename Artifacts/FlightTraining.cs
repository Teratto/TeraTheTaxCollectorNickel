using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using Nanoray.PluginManager;
using Nickel;
using TeraTaxMod.Cards;

namespace TeraTaxMod.Artifacts;

public class FlightTraining : Artifact, IRegisterable
{
    private static ISpriteEntry ActiveSprite = null!;
    private static ISpriteEntry InactiveSprite = null!;
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        ActiveSprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Artifact/FlightTraining.png"));
        InactiveSprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Artifact/FlightTrainingUsedUp.png"));
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
            Sprite = ActiveSprite.Sprite,
        });
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(AStatus), nameof(AStatus.Begin)),
            postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(FlightTraining_Postfix))
            );
    }
    public override int? GetDisplayNumber(State s)
    {
        return taxCounter;
    }


    public int taxCounter = 0;
    public int turnCounter = 0;
    public static void FlightTraining_Postfix(AStatus __instance, State s, Combat c)
    {
        Ship currentShip = __instance.targetPlayer ? s.ship : c.otherShip;

        if (s.EnumerateAllArtifacts().FirstOrDefault(a => a is FlightTraining) is not { } artifact)
            return;
        if (currentShip == s.ship)
            return;
        
        var flightTrainingArti = (FlightTraining)artifact;
        var flightTrainingTurnCounter = (FlightTraining)artifact;

        if (flightTrainingTurnCounter.turnCounter >= 2)
        {
            return;
        }
        if (__instance.status == ModEntry.Instance.TeraTaxationStatus.Status && c.otherShip.Get(ModEntry.Instance.TeraBailoutStatus.Status) == 0 && __instance.statusAmount > 0)
        {
            flightTrainingArti.taxCounter += 1;
        }
        
        if (flightTrainingArti.taxCounter >= 3)
        {
            c.QueueImmediate(new AStatus()
            {
                statusAmount = 1,
                status = Status.evade,
                targetPlayer = true
            });
            flightTrainingArti.taxCounter = 0;
            flightTrainingTurnCounter.turnCounter += 1;
        }
       
    }
    public override Spr GetSprite()
    {
        if (turnCounter < 2)
        {
            return ActiveSprite.Sprite;
        }
    return InactiveSprite.Sprite;
    }
    public override void OnTurnStart(State state, Combat combat)
    {
        turnCounter = 0;
    }

    public override void OnCombatEnd(State state)
    {
        turnCounter = 0;
        taxCounter = 0;
    }

}