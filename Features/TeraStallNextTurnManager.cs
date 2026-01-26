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
using System.Net.NetworkInformation;

namespace TeraTaxMod.Features;


public class TeraStallNextTurnManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{




    public bool HandleStatusTurnAutoStep(IHandleStatusTurnAutoStepArgs args)
    {
        
        if (args.Status != ModEntry.Instance.TeraStallNextStatus.Status)
            return false;
        
        if (args.Timing != IKokoroApi.IV2.IStatusLogicApi.StatusTurnTriggerTiming.TurnStart)
            return false;
        Console.WriteLine("firstif"+args.Timing+args.Status);

        bool isPlayerShip = args.Ship.isPlayerShip;
        
  
        args.Combat.Queue(new AStatus()
            {
                status = ModEntry.Instance.TeraStallNextStatus.Status,
                statusAmount = -1,
                targetPlayer = isPlayerShip

            });   
        args.Combat.Queue(new AStatus()
            {
                status = Status.engineStall,
                statusAmount = 1,
                targetPlayer = isPlayerShip
            });



        return false;
    }
}





