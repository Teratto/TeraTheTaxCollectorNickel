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
        return true;
    }

    //[HarmonyPrefix]
    //[HarmonyPatch(typeof(AStatus), "Begin")]
    public static void AStatus_Begin_Prefix(AStatus __instance, State s, Combat c)
    {
        //if ((__instance.status.isgood && __instance.statusAmount > 0) || (status.isGood && __instance.statusAmount < 0)) { 
            
           // __instance.statusAmount = 0;
            
                
        
        
    }
    public void HandleImmediateStatusTrigger(IHandleImmediateStatusTriggerArgs args) 
        {
          //  if (args.Status != ModEntry.Instance.TeraBailoutStatus.Status) {  return; }
           // bool isPlayerShip = args.Ship.isPlayerShip;
           // bool isItGood = !DB.statuses[args.Status].isGood && args.Status != ModEntry.Instance.TeraBailoutStatus.Status;
           // if ((!args.status.isGood && amount > 0) || (status.isGood && amount < 0)) { amount = 0; }
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





