using BepInEx;
using BepInEx.Logging;
using ResourceAssets;

namespace CraftableShipSystemUpgrader
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency("VoidManager")]
    public class BepinPlugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        private void Awake()
        {
            Log = Logger;
            GUIDUnion guid = new GUIDUnion("49991ea1005c0134cb8e8febcd0dfe8b");
            CraftingRules cr = VoidManager.Content.Craftables.Instance.GetRecipe(guid);
            cr.CraftingMethod = CraftMethod.Resource;
            cr.Creation = new ResourceCurrency(CG.Ship.Object.ResourceType.Alloys, 24);

            VoidManager.Content.Craftables.Instance.SetRecipe(guid, MyPluginInfo.PLUGIN_GUID, cr);

            VoidManager.Content.Unlocks.Instance.SetUnlockOptions(guid, MyPluginInfo.PLUGIN_GUID, new CG.Client.UserData.UnlockOptions() { RankRequirement = 30, UnlockCriteria = CG.Client.UserData.UnlockCriteriaType.PlayerRank});
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}