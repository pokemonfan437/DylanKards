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
    class SuppressiveFire : SimpleCard
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "Suppressive Fire",
            Description = "SUPPRESSIVE FIRE!",
            ModName = DylanKards.ModInitials,
            Art = Assets.SuppressiveFireArt,
            Rarity = CardInfo.Rarity.Rare,
            Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    amount = "Max",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Attack Speed"
                },
                new CardInfoStat()
                {
                    positive = true,
                    amount = "Max",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Ammo"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotLower,
                    stat = "Damage"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "-80%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Final Damage"
                },
                new CardInfoStat()
                {
                    positive = false,
                    amount = "+100%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotOf,
                    stat = "Reload Time"
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            gun.attackSpeed = 0.001f;
            gun.attackSpeedMultiplier = 0.001f;
            gun.damage = 0.5f;
            gun.bulletDamageMultiplier = 0.2f;
            gun.ammo = 100;
            gun.reloadTime = 2f;
            gun.spread = 0.1f;
        }
    }
}