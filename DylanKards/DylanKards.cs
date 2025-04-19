using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using DylanKards.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;


namespace DylanKards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.willis.rounds.modsplus", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class DylanKards : BaseUnityPlugin
    {
        private const string ModId = "com.pokemonfan.rounds.DylanKards";
        private const string ModName = "Dylan Kards";
        public const string Version = "1.4.3"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "DK";
        public static DylanKards instance { get; private set; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            instance = this;
            CustomCard.BuildCard<BigDamage>();
            CustomCard.BuildCard<BounceHouse>();
            CustomCard.BuildCard<Blocked>();
            CustomCard.BuildCard<Cosine>();
            CustomCard.BuildCard<AirStrike>();
            CustomCard.BuildCard<AmmoRegen>();
            CustomCard.BuildCard<SuppressiveFire>();
            CustomCard.BuildCard<ShapedGlass>();
        }
    }
}
