using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework.Graphics;
using DBZGoatLib;
using Terraria.ModLoader;
using DBZGoatLib.Handlers;
using oozaru144port.Assets;

namespace oozaru144port.Transformations
{
    internal class SSJ4Buff : Transformation
    {
        public override AuraData AuraData() => new AuraData("oozaru144port/Assets/BaseAura", 4, BlendState.Additive, new Color(255, 255, 0));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<OPlayer>();

            return !player.HasBuff<SSJ4Buff>() && modPlayer.SSJ4Achieved;
        }

        public override string FormName() => "Super Saiyan 4";

        public override string HairTexturePath() => "oozaru144port/Assets/SSJ4Hair";

        public override Gradient KiBarGradient() => new Gradient(new Color(255, 255, 0)).AddStop(1f, new Color(102, 0, 0));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSJ4Active = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSJ4Active = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ3", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.Gold;

        public override void SetStaticDefaults()
        {
            damageMulti = 3.3f;
            speedMulti = 3.3f;

            kiDrainRate = 3.5f;
            kiDrainRateWithMastery = 1.75f;

            attackDrainMulti = 1f;
            baseDefenceBonus = 16;

            base.SetStaticDefaults(); 
        }
    }
}
