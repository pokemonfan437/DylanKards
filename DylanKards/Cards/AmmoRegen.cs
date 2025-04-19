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
    class AmmoRegen : SimpleCard
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "Ammo Regen",
            Description = "Regenerate ammo each second.",
            ModName = DylanKards.ModInitials,
            Art = null,
            Rarity = CardInfo.Rarity.Uncommon,
            Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    amount = "+10%",
                    simepleAmount = CardInfoStat.SimpleAmount.Some,
                    stat = "Ammo per second"
                },
                new CardInfoStat()
                {
                    positive = true,
                    amount = "+25%",
                    simepleAmount = CardInfoStat.SimpleAmount.Some,
                    stat = "Attack Speed"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "-30%",
                    simepleAmount = CardInfoStat.SimpleAmount.slightlyLower,
                    stat = "Damage"
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            gun.ammoReg += 0.1f;
            gun.attackSpeed *= 1.25f;
            gun.damage *= 0.7f;
        }
    }
}