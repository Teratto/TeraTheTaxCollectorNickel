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
        if (args.Timing != IKokoroApi.IV2.IStatusLogicApi.StatusTurnTriggerTiming.TurnStart)
            return false;
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

            //If the amount on a ship > damage threshold on turn start, do damage equal to amount / damage threshold. Ignore remainder. 

            return false;
    }
}





