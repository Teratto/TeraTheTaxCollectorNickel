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

namespace TeraTaxMod.Features;


public class TeraLockNextTurnManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{
    public bool HandleStatusTurnAutoStep(IHandleStatusTurnAutoStepArgs args)
    {
        if (args.Status != ModEntry.Instance.TeraLockNextStatus.Status)
            return false;
        
        if (args.Timing != IKokoroApi.IV2.IStatusLogicApi.StatusTurnTriggerTiming.TurnStart)
            return false;
        
        bool isPlayerShip = args.Ship.isPlayerShip;
        
  
        args.Combat.QueueImmediate(new AStatus()
            {
                status = ModEntry.Instance.TeraLockNextStatus.Status,
                statusAmount = -1,
                targetPlayer = isPlayerShip

            });
        args.Combat.QueueImmediate(new AStatus()
        {
            status = Status.lockdown,
            statusAmount = 1,
            targetPlayer = isPlayerShip

        });




        return false;
    }
    public bool? IsAffectedByBoost(IKokoroApi.IV2.IStatusLogicApi.IHook.IIsAffectedByBoostArgs args)
            => args.Status == ModEntry.Instance.TeraLockNextStatus.Status ? true : null;
}





