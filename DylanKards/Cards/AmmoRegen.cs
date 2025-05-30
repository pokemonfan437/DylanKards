﻿using System;
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
            Art = Assets.AmmoRegenArt,
            Rarity = CardInfo.Rarity.Uncommon,
            Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    amount = "+20%",
                    simepleAmount = CardInfoStat.SimpleAmount.Some,
                    stat = "Ammo per second"
                },
                new CardInfoStat()
                {
                    positive = true,
                    amount = "+5",
                    simepleAmount = CardInfoStat.SimpleAmount.Some,
                    stat = "Ammo"
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
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.slightlyLower,
                    stat = "Damage"
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            gun.ammoReg = 0.2f;
            gun.ammo = 5;
            gun.attackSpeed = 0.75f;
            gun.damage = 0.5f;
        }
    }
}