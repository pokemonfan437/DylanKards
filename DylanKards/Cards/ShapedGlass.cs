using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModsPlus;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;


namespace DylanKards.Cards
{
    class ShapedGlass : SimpleCard
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "Shaped Glass",
            Description = "Triples your damage at the cost of your health.",
            ModName = DylanKards.ModInitials,
            Art = null,
            Rarity = CardInfo.Rarity.Rare,
            Theme = CardThemeColor.CardThemeColorType.ColdBlue,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    amount = "x3",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Final Damage Multiplier\""
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotLower,
                    stat = "Health"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "+1s",
                    simepleAmount = CardInfoStat.SimpleAmount.Some,
                    stat = "Reload Time"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "-25%",
                    simepleAmount = CardInfoStat.SimpleAmount.slightlyLower,
                    stat = "Attack Speed"
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            gun.bulletDamageMultiplier *= 3f;
            statModifiers.health *= 0.25f;
            gun.reloadTimeAdd += 1f;
            gun.attackSpeed *= 1.25f;
        }
    }
}