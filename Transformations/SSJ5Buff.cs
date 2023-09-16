using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework.Graphics;
using DBZGoatLib;
using Terraria.ModLoader;
using DBZGoatLib.Handlers;
using oozaru.Assets;

namespace oozaru.Transformations
{
    internal class SSJ5Buff : Transformation 
    {
        public override AuraData AuraData() => new AuraData("oozaru/Assets/SSJ5AURA", 8, BlendState.Additive, new Color(153, 153, 153));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<OPlayer>();

            return !player.HasBuff<SSJ5Buff>() && modPlayer.SSJ5Achieved;

        }

        public override string FormName() => "Super Sayian 5";

        public override string HairTexturePath() => "oozaru/Assets/SSJ5HAIR";

        public override Gradient KiBarGradient() => new Gradient(new Color(243, 246, 244)).AddStop(1f, new Color(91, 91, 91));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSJ5Active = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSJ5Active = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ3", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.Silver;

        public override void SetStaticDefaults()
        {
            damageMulti = 4.8f;
            speedMulti = 4.8f;

            kiDrainRate = 8f;
            kiDrainRateWithMastery = 2f;

            attackDrainMulti = 2.5f;
            baseDefenceBonus = 32;

            base.SetStaticDefaults();
        }
    }
}
