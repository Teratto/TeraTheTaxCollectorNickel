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

namespace TeraTaxMod.Features;


public class TeraTaxationManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{
    public void OnStatusTurnTrigger(IOnStatusTurnTriggerArgs args)
    {
        bool inflationGet = s.artifacts.Find(a => a.GetType() == typeof(Inflation)) != null;

        if (args.Status != ModEntry.Instance.TeraTaxationStatus.Status)
            return;
        if (args.Timing != IKokoroApi.IV2.IStatusLogicApi.StatusTurnTriggerTiming.TurnEnd)
            return;
        int taxationDamageThreshold = inflationGet == true ? 2 : 3;
        
        bool isPlayerShip = args.Ship.isPlayerShip;
        if (args.Ship.Get(ModEntry.Instance.TeraTaxationStatus.Status) >= taxationDamageThreshold) 
        {

            args.Combat.QueueImmediate(new AHurt()
            {
                targetPlayer = isPlayerShip,
                hurtShieldsFirst = true,
                hurtAmount = args.NewAmount / taxationDamageThreshold,

            });
        }
        
           
        return;
    }
   

}





