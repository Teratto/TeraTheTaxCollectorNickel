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

namespace TeraTaxMod.Features;


public class TeraPersistenceManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{
    

    public TeraPersistenceManager()
    {
        ModEntry.Instance.KokoroApi.StatusLogic.RegisterHook(this);
    }




    public bool OnStatusTurnTrigger(IOnStatusTurnTriggerArgs args )
    {
        if (args.Status != ModEntry.Instance.TeraPersistenceStatus.Status)
            return false;

            //If the amount on a ship > damage threshold on turn start, do damage equal to amount / damage threshold. Ignore remainder. 

            return false;
    }
}





