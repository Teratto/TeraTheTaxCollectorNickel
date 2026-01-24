using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TeraTaxMod.External;
using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using static TeraTaxMod.External.IKokoroApi.IV2.IStatusLogicApi.IHook;

namespace TeraTaxMod.Features;


public class TeraTaxationManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{
    

    public TeraTaxationManager()
    {
        ModEntry.Instance.KokoroApi.StatusLogic.RegisterHook(this);
    }




    public bool OnStatusTurnTrigger(IOnStatusTurnTriggerArgs args )
    {
        int taxationDamageThreshold = 3;
        //if player has inflation relic, set threshold to 2

        if (args.Status != ModEntry.Instance.TeraTaxationStatus.Status)
            return false;
        if (args.Timing == IKokoroApi.IV2.IStatusLogicApi.StatusTurnTriggerTiming.TurnEnd)
            
            if (args.NewAmount == 0)
                return false;
            if (args.NewAmount != 0) {
                bool isPlayerShip = args.Ship.isPlayerShip;
                args.Combat.QueueImmediate(new AHurt() { 
                    hurtShieldsFirst = true,
                    hurtAmount = args.NewAmount / taxationDamageThreshold,
                    targetPlayer = isPlayerShip
                });
       
            }
            return false;
    }
    public bool HandleStatusturnAutoStep(IHandleStatusTurnAutoStepArgs args)
    {
        if (args.Status != ModEntry.Instance.TeraTaxationStatus.Status)
            return false;
        int persistenceAmount = args.Ship.Get(ModEntry.Instance.TeraPersistenceStatus.Status);
        if (args.Timing == IKokoroApi.IV2.IStatusLogicApi.StatusTurnTriggerTiming.TurnStart)
            {
                if (persistenceAmount > 0)
                {
                args.Amount += persistenceAmount;
                }
            }



            return false;
    }

}





