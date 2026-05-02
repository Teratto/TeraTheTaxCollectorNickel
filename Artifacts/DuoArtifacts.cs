using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using TeraTaxMod.Cards;
using TeraTaxMod.External;
using static TeraTaxMod.External.IKokoroApi.IV2.IStatusLogicApi.IHook;
using TeraTaxMod.External;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json.Linq;
using JetBrains.Annotations;
using System;
using System.Net.NetworkInformation;
using System.Diagnostics.Metrics;
using TeraTaxMod.Midrow;

namespace TeraTaxMod.Artifacts;

public interface IDuoArtifact
{
    public static abstract void Register(IPluginPackage<IModManifest> package, IModHelper helper, IDuoApi duoApi);
}
public class FireSale : Artifact, IDuoArtifact
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper, IDuoApi duoApi)
    {
     

        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration


        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                pools = [ArtifactPool.Common],
                owner = duoApi.DuoArtifactVanillaDeck,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Drake", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Drake", "desc"]).Localize,

            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Duo/FireSale.png")).Sprite
        });
        duoApi.RegisterDuoArtifact(MethodBase.GetCurrentMethod()!.DeclaringType!,
            [ModEntry.Instance.TeraTaxDeck.Deck, Deck.eunice]);

    }

    public override void OnTurnStart(State s, Combat c)
    {
        base.OnTurnEnd(s, c);
        int playerHeat = s.ship.Get(Status.heat);
        if (playerHeat >= 2)
        {
            c.QueueImmediate(new AStatus()
            {
                status = ModEntry.Instance.TeraBailoutStatus.Status,
                statusAmount = 1,
                targetPlayer = true,
                artifactPulse = Key()
            });
        }

    }

    public override List<Tooltip> GetExtraTooltips()
         => [
             .. StatusMeta.GetTooltips(ModEntry.Instance.TeraBailoutStatus.Status, 1),
             .. StatusMeta.GetTooltips(Status.heat, 2),
            ];

        
}



public class MonetaryShock : Artifact, IDuoArtifact
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper, IDuoApi duoApi)
    {


        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration


        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                pools = [ArtifactPool.Common],
                owner = duoApi.DuoArtifactVanillaDeck,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Dizzy", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Dizzy", "desc"]).Localize,

            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Duo/MonetaryShock.png")).Sprite
        });
        duoApi.RegisterDuoArtifact(MethodBase.GetCurrentMethod()!.DeclaringType!,
            [ModEntry.Instance.TeraTaxDeck.Deck, Deck.dizzy]);
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Card), nameof(Card.GetActionsOverridden)),
            postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Monetary_Shock_Postfix))
        );
    }


     

    public static void Monetary_Shock_Postfix(Card __instance, State s, List<CardAction> __result)
    {
        if (s.EnumerateAllArtifacts().FirstOrDefault(a => a is MonetaryShock) is not { } artifact)
            return;
   
        foreach (var baseAction in __result)
        {
            foreach (var wrappedAction in ModEntry.Instance.KokoroApi.WrappedActions.GetWrappedCardActionsRecursively(baseAction))
            {
                if (wrappedAction is AAttack aAttack && __instance.GetMeta()?.deck == ModEntry.Instance.TeraTaxDeck.Deck)
                {
                   aAttack.stunEnemy = true;
                }
            }
                
        }
       
    }
}

public class WireTransfer : Artifact, IDuoArtifact
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper, IDuoApi duoApi)
    {


        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration


        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                pools = [ArtifactPool.Common],
                owner = duoApi.DuoArtifactVanillaDeck,
            }, 
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "CAT", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "CAT", "desc"]).Localize,

            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Duo/Economics.png")).Sprite
        });
        duoApi.RegisterDuoArtifact(MethodBase.GetCurrentMethod()!.DeclaringType!,
            [ModEntry.Instance.TeraTaxDeck.Deck, Deck.colorless]);
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Card), nameof(Card.GetActionsOverridden)),
            postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Wire_Transfer_Postfix))
        );
    }




    public static void Wire_Transfer_Postfix(Card __instance, State s, List<CardAction> __result)
    {
        if (s.EnumerateAllArtifacts().FirstOrDefault(a => a is WireTransfer) is not { } artifact)
            return;

        foreach (var baseAction in __result)
        {
            foreach (var wrappedAction in ModEntry.Instance.KokoroApi.WrappedActions.GetWrappedCardActionsRecursively(baseAction))
            {
                if (wrappedAction is AAttack aAttack && __instance is CannonColorless)
                {
                    aAttack.status = ModEntry.Instance.TeraTaxationStatus.Status;
                    aAttack.statusAmount = 1;
                }
            }

        }

    }
    public override List<Tooltip> GetExtraTooltips()
        => [
            .. StatusMeta.GetTooltips(ModEntry.Instance.TeraTaxationStatus.Status, 1),
        ];
}
public class YearlyCycle : Artifact, IDuoArtifact
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper, IDuoApi duoApi)
    {


        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration


        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                pools = [ArtifactPool.Common],
                owner = duoApi.DuoArtifactVanillaDeck,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Riggs", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Riggs", "desc"]).Localize,

            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Duo/YearlyCycle.png")).Sprite
        });
        duoApi.RegisterDuoArtifact(MethodBase.GetCurrentMethod()!.DeclaringType!,
            [ModEntry.Instance.TeraTaxDeck.Deck, Deck.riggs]);
    }



    public override int? GetDisplayNumber(State s)
    {
        return cardCounter;
    }

    public int cardCounter = 0;
    public override void OnDrawCard(State s, Combat c, int count)
    {
        if (s.EnumerateAllArtifacts().FirstOrDefault(a => a is YearlyCycle) is not { } artifact)
            return;
        cardCounter += count;
        if (cardCounter >= 12)
        {
            cardCounter -= 12;
            c.QueueImmediate(new AStatus
            {
                status = ModEntry.Instance.TeraTaxationStatus.Status,
                targetPlayer = false,
                statusAmount = 1,
                artifactPulse = Key()
            });
        }
        if (cardCounter >= 12)
        {
            cardCounter -= 12;
            c.QueueImmediate(new AStatus
            {
                status = ModEntry.Instance.TeraTaxationStatus.Status,
                targetPlayer = false,
                statusAmount = 1,
                artifactPulse = Key()
            });  
        }
    }
    public override List<Tooltip> GetExtraTooltips()
        => [
            .. StatusMeta.GetTooltips(ModEntry.Instance.TeraTaxationStatus.Status, 1),
        ];
}
public class AssetLiquidation : Artifact, IDuoArtifact
{
    public bool WaitingForActionDrain;
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper, IDuoApi duoApi)
    {


        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration


        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                pools = [ArtifactPool.Common],
                owner = duoApi.DuoArtifactVanillaDeck,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Max", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Max", "desc"]).Localize,

            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Duo/AssetLiquidation.png")).Sprite
        });
        duoApi.RegisterDuoArtifact(MethodBase.GetCurrentMethod()!.DeclaringType!,
            [ModEntry.Instance.TeraTaxDeck.Deck, Deck.hacker]);
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Combat), nameof(Combat.SendCardToExhaust)),
            postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AssetLiquidation_Postfix))
        );
    }


    public override int? GetDisplayNumber(State s)
    {
        return exhaustCounter;
    }
    public int exhaustCounter = 0;

    public override void OnCombatStart(State state, Combat combat)
    {
        base.OnCombatStart(state, combat);
        WaitingForActionDrain = false;
    }
    public override void OnQueueEmptyDuringPlayerTurn(State state, Combat combat)
    {
        base.OnQueueEmptyDuringPlayerTurn(state, combat);
        if (!WaitingForActionDrain)
            return;

        WaitingForActionDrain = false;
        if (exhaustCounter < 1)
        {
            exhaustCounter += 1;
            return;
        }
            
        exhaustCounter = 0;
        combat.Queue(new AStatus
        {
            targetPlayer = true,
            status = ModEntry.Instance.TeraBailoutStatus.Status,
            statusAmount = 1,
            artifactPulse = Key(),
        });
        
    }
    private static void AssetLiquidation_Postfix(State s)
    {
        if (s.EnumerateAllArtifacts().OfType<AssetLiquidation>().FirstOrDefault() is not { } artifact)
            return;
        artifact.WaitingForActionDrain = true;
    }
    public override List<Tooltip> GetExtraTooltips()
        => [
            .. StatusMeta.GetTooltips(ModEntry.Instance.TeraBailoutStatus.Status, 1),
        ];
}
public class Improvisation : Artifact, IDuoArtifact
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper, IDuoApi duoApi)
    {


        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration


        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                pools = [ArtifactPool.Common],
                owner = duoApi.DuoArtifactVanillaDeck,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Isaac", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Isaac", "desc"]).Localize,
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Duo/Improvisation.png")).Sprite
        });
        duoApi.RegisterDuoArtifact(MethodBase.GetCurrentMethod()!.DeclaringType!,
            [ModEntry.Instance.TeraTaxDeck.Deck, Deck.goat]);
        TaxationDrone.Register(package, helper);
    }

    public override List<Tooltip> GetExtraTooltips()
        => [new TTCard { card = new TaxationDrone() }];
    public override void OnCombatStart(State state, Combat combat)
    {
        combat.Queue(new AAddCard()
        {
            card = new TaxationDrone(),
            destination = CardDestination.Hand,
            artifactPulse = Key()
        });
    }
    internal class TaxationDrone : Card, IRegisterable
    {
        public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
        {
            helper.Content.Cards.RegisterCard(new CardConfiguration
            {
                CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
                Meta = new CardMeta
                {
                    deck = ModEntry.Instance.DuoArtifactApi!.DuoArtifactVanillaDeck,
                    rarity = Rarity.common,
                    dontOffer = true,
                    upgradesTo = [Upgrade.A, Upgrade.B]
                },
                Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "TaxationDrone", "name"]).Localize,
                Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Duo/CardAudit.png")).Sprite,
            });
        }


        public override List<CardAction> GetActions(State s, Combat c)
        {
            switch (this.upgrade)
            {
                case Upgrade.None:
                    {
                        return new List<CardAction>
                    {
                        new ASpawn()
                        {
                            thing = new TaxDrone
                            {
                                yAnimation = 0.0
                            },
                        }
                    };
                    }
                case Upgrade.A:
                    {
                        return new List<CardAction>
                    {
                        new ASpawn()
                        {
                            thing = new TaxDrone
                            {
                                yAnimation = 0.0,
                                bubbleShield = true,
                            },
                        },
                        new AStatus()
                        {
                            statusAmount = 2,
                            status = Status.droneShift,
                            targetPlayer = true
                        }
                    };
                    }
                case Upgrade.B:
                    {
                        return new List<CardAction>
                    {
                        new ASpawn()
                        {
                            thing = new TaxDrone
                            {
                                yAnimation = 0.0
                            },
                        },
                        new ASpawn()
                        {
                            thing = new TaxDrone
                            {
                                yAnimation = 0.0
                            },
                            offset = -1
                        },

                    };
                    }
                default:
                    {
                        return new List<CardAction>
                    {
                        new ASpawn()
                        {
                            thing = new TaxDrone
                            {
                                yAnimation = 0.0
                            },
                        }
                    };
                    }
            }

        }


        public override CardData GetData(State state)
        {
            return new CardData
            {
                cost = 1,
                temporary = true
            };
        }

    }
}
public class Scrutiny : Artifact, IDuoArtifact
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper, IDuoApi duoApi)
    {


        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration


        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                pools = [ArtifactPool.Common],
                owner = duoApi.DuoArtifactVanillaDeck,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Peri", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Peri", "desc"]).Localize,

            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Duo/CollectorsBestFriend.png")).Sprite
        });
        duoApi.RegisterDuoArtifact(MethodBase.GetCurrentMethod()!.DeclaringType!,
            [ModEntry.Instance.TeraTaxDeck.Deck, Deck.peri]);
    }
    public override List<Tooltip> GetExtraTooltips()
       => [
           .. StatusMeta.GetTooltips(ModEntry.Instance.TeraBailoutStatus.Status, 1),
           .. StatusMeta.GetTooltips(Status.overdrive, 2),
       ];

}
public class GemstonePrinter : Artifact, IDuoArtifact
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper, IDuoApi duoApi)
    {


        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration


        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                pools = [ArtifactPool.Common],
                owner = duoApi.DuoArtifactVanillaDeck,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Books", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "Books", "desc"]).Localize,

            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/Duo/MoneyLaundering.png")).Sprite
        });
        duoApi.RegisterDuoArtifact(MethodBase.GetCurrentMethod()!.DeclaringType!,
            [ModEntry.Instance.TeraTaxDeck.Deck, Deck.shard]);
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(AStatus), nameof(AStatus.Begin)),
            prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(GemstonePrinter_Postfix))
            );

    }
    public override int? GetDisplayNumber(State s)
    {
        return shardCounter;
    }
    public int shardCounter = 0;
    public static void GemstonePrinter_Postfix(AStatus __instance, State s, Combat c)
    {
        if (s.EnumerateAllArtifacts().FirstOrDefault(a => a is GemstonePrinter) is not { } artifact)
            return;

        Ship currentShip = __instance.targetPlayer ? s.ship : c.otherShip;

        var gemstonePrinterArtifact = (GemstonePrinter)artifact;

        var getMaxShard = s.ship.GetMaxShard();
        var getCurrentShard = s.ship.Get(Status.shard);

        if (__instance.status == Status.shard && ((getCurrentShard + __instance.statusAmount) > getMaxShard) && currentShip == s.ship)
        {
            gemstonePrinterArtifact.shardCounter += 1;
            if (gemstonePrinterArtifact.shardCounter >= 2)
            {
                c.QueueImmediate(new AStatus()
                {
                    statusAmount = 1,
                    status = ModEntry.Instance.TeraTaxationStatus.Status,
                    targetPlayer = false
                });
                gemstonePrinterArtifact.shardCounter = 0;
            }
            
  
        }
    }



    public override void OnCombatEnd(State state)
    {
        shardCounter = 0;
    }
    public override List<Tooltip> GetExtraTooltips()
       => [
           .. StatusMeta.GetTooltips(Status.shard, 1),
           .. StatusMeta.GetTooltips(ModEntry.Instance.TeraTaxationStatus.Status, 2),
       ];
}

