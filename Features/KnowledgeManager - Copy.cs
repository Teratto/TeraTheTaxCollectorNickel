using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TeraTaxMod.External;
using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using static Shockah.Kokoro.IKokoroApi.IV2;

namespace TeraTaxMod.Features;


public class TeraTaxationManager : IKokoroApi.IV2.StatusLogic.IHook
{
    

    public TeraTaxationManager()
    {
        ModEntry.Instance.KokoroApi.StatusLogic.RegisterHook(this);
        ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this, 0);
    }

  


    public bool HandleStatusTurnAutoStep(IHandleStatusTurnAutoStepArgs args)
    {

        if (args.Status != ModEntry.Instance.TeraTaxation.Status)
            return false;
        if (args.Timing != StatusTurnTriggerTiming.TurnStart)
            return false;
        if (args.Amount > 0)
        {
            args.Combat.QueueImmediate(
                new AAddCard()
                {
                    card = new VicAux()
                    {
                    },
                    destination = CardDestination.Hand,
                    amount = args.Amount,
                });
        }
        return false;
    }
}





