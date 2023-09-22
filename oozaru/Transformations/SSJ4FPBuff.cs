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
    internal class SSJ4FPBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("oozaru/Assets/BaseAura", 4, BlendState.Additive, new Color(255, 0, 0));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<OPlayer>();

            return !player.HasBuff<SSJ4FPBuff>() && modPlayer.SSJ4FPAchieved;
        }

        public override string FormName() => "Super Saiyan 4 Full Power";

        public override string HairTexturePath() => "oozaru/Assets/SSJ4FPHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(255, 255, 0)).AddStop(1f, new Color(102, 0, 0));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSJ4FPActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().SSJ4FPActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ3", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.IndianRed;

        public override void SetStaticDefaults()
        {
            damageMulti = 3.8f;
            speedMulti = 3.8f;

            kiDrainRate = 4.8f;
            kiDrainRateWithMastery = 2.4f;

            attackDrainMulti = 1.5f;
            baseDefenceBonus = 20;

            base.SetStaticDefaults();
        }

    }
}
