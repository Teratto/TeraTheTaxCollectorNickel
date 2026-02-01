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

namespace TeraTaxMod.Features;


public class TeraBailoutManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{
    public int ModifyStatusChange(IModifyStatusChangeArgs args)
    {
        if (args.Status == ModEntry.Instance.TeraBailoutStatus.Status)
            return args.NewAmount;
        
        bool isItGood = DB.statuses[args.Status].isGood;

        bool isPlayerShip = args.Ship.isPlayerShip;

        if ((args.Ship.Get(ModEntry.Instance.TeraBailoutStatus.Status) > 0) && (isItGood == false && args.NewAmount > args.OldAmount || isItGood == true && args.NewAmount < args.OldAmount))
        {
   
            args.Combat.QueueImmediate(new AStatus()
            {
                status = ModEntry.Instance.TeraBailoutStatus.Status,
                statusAmount = -1,
                targetPlayer = isPlayerShip
            });
            return args.OldAmount;
        }

        return args.NewAmount;
    }
    public bool? IsAffectedByBoost(IIsAffectedByBoostArgs args)
            => args.Status == ModEntry.Instance.TeraBailoutStatus.Status ? true : null;




    //NOTE: INCLUDE CODE THAT MAKES THE ISMISSING DIALOGUE ONLY RUN IF BAILOUT IS NOT TRIGGERED. 
    //Detect every status a ship gets ever.
    //if that status isgood and -int, set value to 0 (before ship gains status) and -1 bailout
    // do the opposite for when the status is not good


}





