using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TeraTaxMod.External;
using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using static TeraTaxMod.External.IKokoroApi.IV2.IStatusLogicApi.IHook;
using TeraTaxMod.Artifacts;
using JetBrains.Annotations;
using TeraTaxMod.Features;

namespace TeraTaxMod.Features;

public class TeraDividendsManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{
    public double ModifyStatusTurnTriggerPriority(IKokoroApi.IV2.IStatusLogicApi.IHook.IModifyStatusTurnTriggerPriorityArgs args)
        => args.Status == ModEntry.Instance.TeraDividendsStatus.Status ? args.Priority + 20 : args.Priority +20;
    public bool HandleStatusTurnAutoStep(IHandleStatusTurnAutoStepArgs args)
    {
        if (args.Status != ModEntry.Instance.TeraDividendsStatus.Status)
            return false;

        if (args.Timing != IKokoroApi.IV2.IStatusLogicApi.StatusTurnTriggerTiming.TurnStart)
            return false;

        bool isPlayerShip = args.Ship.isPlayerShip;
        int dividendsAmount = args.Amount;

        if (args.Ship.Get(ModEntry.Instance.TeraBailoutStatus.Status) <= 0)
        {
            args.Combat.QueueImmediate( new AStatus()
            {
                status = ModEntry.Instance.TeraBailoutStatus.Status,
                statusAmount = dividendsAmount,
                targetPlayer = isPlayerShip
            });
        }




        return false;
    }
    
    public bool? IsAffectedByBoost(IIsAffectedByBoostArgs args)
            => args.Status == ModEntry.Instance.TeraTaxationStatus.Status ? false : null;


}





