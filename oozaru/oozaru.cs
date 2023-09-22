using Terraria.ModLoader;
using oozaru.Assets;

namespace oozaru
{
	public class oozaru : Mod
	{
        public static Mod Instance;

        public override void Unload()
        {
            Instance = null;
            oozaru.Instance = null;
            OPlayer.PowerUp = null;
        }

        public override void Load()
        {
            oozaru.Instance = this;
            OPlayer.PowerUp = KeybindLoader.RegisterKeybind(oozaru.Instance, "Power Up (oozaru Mod)", "Z");
        }
    }
}