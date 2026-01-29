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


public class TeraPersistenceManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{
    



    public bool HandleStatusTurnAutoStep(IHandleStatusTurnAutoStepArgs args)
    {
        if (args.Status != ModEntry.Instance.TeraPersistenceStatus.Status)
            return false;
        
        if (args.Timing != IKokoroApi.IV2.IStatusLogicApi.StatusTurnTriggerTiming.TurnStart)
            return false;
        
        int persistenceAmount = args.Amount;
        bool isPlayerShip = args.Ship.isPlayerShip;


        args.Combat.QueueImmediate(new AStatus()
            {
                status = ModEntry.Instance.TeraTaxationStatus.Status,
                statusAmount = persistenceAmount,
                targetPlayer = isPlayerShip


            });
        



        return false;
    }
    public bool? IsAffectedByBoost(IIsAffectedByBoostArgs args)
            => args.Status == ModEntry.Instance.TeraPersistenceStatus.Status ? true : null;
}





