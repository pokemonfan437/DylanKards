using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace DylanKards
{
    internal class Assets
    {
        private static readonly AssetBundle Bundle = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("dylankardart", typeof(DylanKards).Assembly);


        public static GameObject BigDamageArt = Bundle.LoadAsset<GameObject>("C_BigDamage");
        public static GameObject BounceHouseArt = Bundle.LoadAsset<GameObject>("C_BounceHouse");
        public static GameObject BlockedArt = Bundle.LoadAsset<GameObject>("C_Blocked");
        public static GameObject CosineArt = Bundle.LoadAsset<GameObject>("C_Cosine");
        public static GameObject AirStrikeArt = Bundle.LoadAsset<GameObject>("C_Airstrike");
        public static GameObject AmmoRegenArt = Bundle.LoadAsset<GameObject>("C_AmmoRegen");
        public static GameObject SuppressiveFireArt = Bundle.LoadAsset<GameObject>("C_SuppressiveFire");
        public static GameObject ShapedGlassArt = Bundle.LoadAsset<GameObject>("C_ShapedGlass");
        public static GameObject DoubleBoomArt = Bundle.LoadAsset<GameObject>("C_DoubleBoom");
        public static GameObject EZAimArt = Bundle.LoadAsset<GameObject>("C_EZAim");

    }
}
