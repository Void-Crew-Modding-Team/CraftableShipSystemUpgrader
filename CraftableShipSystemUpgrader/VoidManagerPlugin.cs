using VoidManager.MPModChecks;

namespace CraftableShipSystemUpgrader
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.All;

        public override string Author => "Dragon";

        public override string Description => "Makes ship system upgraders craftable. All must have.";
    }
}
