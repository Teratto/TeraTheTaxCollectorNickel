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
using System.Reflection;
using static TeraTaxMod.External.IKokoroApi.IV2.IStatusRenderingApi;


namespace TeraTaxMod.Features;


public class TeraBailoutManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{
    public TeraBailoutManager()
    {
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(AStatus), nameof(AStatus.Begin)),
            prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AStatusBailout_Begin_Prefix))
            );
    }

    public static void AStatusBailout_Begin_Prefix(AStatus __instance, State s, Combat c)
    {
        Ship currentShip = __instance.targetPlayer ? s.ship : c.otherShip;
        if (currentShip == null || currentShip.hull <= 0)
        { 
            return;
        }
        if (__instance.status == ModEntry.Instance.TeraBailoutStatus.Status || __instance.status == Status.tempShield || __instance.status == Status.shield)
        {
            return;
        }
        if (__instance.mode != AStatusMode.Add)
        {
            return;
        }
        bool isItGood = DB.statuses[__instance.status].isGood;
        bool governmentGrantsGet = s.EnumerateAllArtifacts().Find(a => a.GetType() == typeof(GovernmentGrant)) != null;

        int currentStatusValue = currentShip.Get(__instance.status);
        int currentBailout = currentShip.Get(ModEntry.Instance.TeraBailoutStatus.Status);

        if (__instance.status == Status.heat && currentShip.Get(Status.serenity) > 0)
        {
            return;
        };

        if (__instance.statusAmount > 0 && currentBailout > 0 && isItGood == false)
        {
            
            __instance.statusAmount = 0;
            if (governmentGrantsGet == true && currentShip == s.ship)
            {
                c.QueueImmediate(new AStatus()
                {
                    status = ModEntry.Instance.TeraTaxationStatus.Status,
                    statusAmount = 1,
                    targetPlayer = false,
                });

            }
            c.QueueImmediate(new AStatus()
            {
                targetPlayer = __instance.targetPlayer,
                statusAmount = -1,
                status = ModEntry.Instance.TeraBailoutStatus.Status,
                statusPulse = ModEntry.Instance.TeraBailoutStatus.Status,
            });

            
        }
        return;
    }
    
   
    public bool? IsAffectedByBoost(IIsAffectedByBoostArgs args)
            => args.Status == ModEntry.Instance.TeraBailoutStatus.Status ? true : null;




    //NOTE: INCLUDE CODE THAT MAKES THE ISMISSING DIALOGUE ONLY RUN IF BAILOUT IS NOT TRIGGERED. 
    //Detect every status a ship gets ever.
    //if that status isgood and -int, set value to 0 (before ship gains status) and -1 bailout
    // do the opposite for when the status is not good


}





