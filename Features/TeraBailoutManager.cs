using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TeraTaxMod.External;
using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using TeraTaxMod.Features;
using static TeraTaxMod.External.IKokoroApi.IV2.IStatusLogicApi.IHook;
using Microsoft.Extensions.Logging;
using TeraTaxMod.Artifacts;
using System.Net.NetworkInformation;
using static TeraTaxMod.External.IKokoroApi.IV2.IStatusLogicApi;

namespace TeraTaxMod.Features;


public class TeraBailoutManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{


    //isGood = true 
    // ----- pos int, do nothing. neg int, negate
    //isGood = false
    // ----- pos int, negate, neg int, do nothing
    //isGood is set to a value
    public bool CanHandleImmediateStatusTrigger(ICanHandleImmediateStatusTriggerArgs args)
    {
        Console.WriteLine("Hello AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA!");
        return true;
    }
    //public static bool AStatus_Begin_Prefix(AStatus __instance, G g, State s, Combat c)


    public void HandleImmediateStatusTrigger(IHandleImmediateStatusTriggerArgs args)
    {
        Console.WriteLine("Hello!");
        if (args.Status == ModEntry.Instance.TeraBailoutStatus.Status)
            return;
        
        if (args.SetStrategy == StatusTurnAutoStepSetStrategy.QueueSet || args.SetStrategy == StatusTurnAutoStepSetStrategy.QueueImmediateSet)
        {
            return;
        }
        bool isItGood = DB.statuses[args.Status].isGood;
        bool isPlayerShip = args.Ship.isPlayerShip;

        if ((args.Ship.Get(ModEntry.Instance.TeraBailoutStatus.Status) > 0) && (isItGood == false && args.NewAmount > 0 || isItGood == true && args.NewAmount < 0))
        {
            args.NewAmount = args.OldAmount;

            args.Combat.QueueImmediate(new AStatus()
            {
                status = ModEntry.Instance.TeraBailoutStatus.Status,
                statusAmount = -1,
                targetPlayer = isPlayerShip
            });
        }

        return;
    }




    //NOTE: INCLUDE CODE THAT MAKES THE ISMISSING DIALOGUE ONLY RUN IF BAILOUT IS NOT TRIGGERED. 
    //Detect every status a ship gets ever.
    //if that status isgood and -int, set value to 0 (before ship gains status) and -1 bailout
    // do the opposite for when the status is not good

    public bool HandleStatusTurnAutoStep(IHandleStatusTurnAutoStepArgs args)
    {

        return false;
    }
}





