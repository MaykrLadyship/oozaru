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
    internal class SSJ5FPBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("oozaru144port/Assets/SSJ5FPAURA", 8, BlendState.Additive, new Color(153, 153, 153));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<OPlayer>();

            return !player.HasBuff<SSJ5FPBuff>() && modPlayer.SSJ5FPAchieved;

        }

        public override string FormName() => "SSJ5 Full Power";

        public override string HairTexturePath() => "oozaru144port/Assets/SSJ5HAIR";

        public override Gradient KiBarGradient() => new Gradient(new Color(243, 246, 244)).AddStop(1f, new Color(91, 91, 91));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSJ5FPActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSJ5FPActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ3", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.Purple;

        public override void SetStaticDefaults()
        {
            damageMulti = 5f;
            speedMulti = 5f;

            kiDrainRate = 9.5f;
            kiDrainRateWithMastery = 3.5f;

            attackDrainMulti = 3f;
            baseDefenceBonus = 37;

            base.SetStaticDefaults();
        }
    }
}
