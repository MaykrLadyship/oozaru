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
    internal class SSJ4LBBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("oozaru/Assets/BaseAura", 4, BlendState.Additive, new Color(240, 59, 91));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<OPlayer>();

            return !player.HasBuff<SSJ4LBBuff>() && modPlayer.SSJ4LBAchieved;
        }

        public override string FormName() => "Super Saiyan 4 Limit Breaker";

        public override string HairTexturePath() => "oozaru/Assets/SSJ4LBH";

        public override Gradient KiBarGradient() => new Gradient(new Color(255, 255, 0)).AddStop(1f, new Color(102, 0, 0));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSJ4LBActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSJ4LBActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ3", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.HotPink;

        public override void SetStaticDefaults()
        {
            damageMulti = 4.2f;
            speedMulti = 4.2f;

            kiDrainRate = 6f;
            kiDrainRateWithMastery = 3f;

            attackDrainMulti = 2f;
            baseDefenceBonus = 26;

            base.SetStaticDefaults();
        }

    }
}
