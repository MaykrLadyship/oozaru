using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using oozaru.Helpers;
//using oozaru.Model;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using DBZGoatLib.Model;
using DBZGoatLib.Handlers;
using DBZGoatLib;
using oozaru.Assets;
using Microsoft.Xna.Framework.Graphics;

namespace oozaru.Transformations
{
    public class LSSJ4Buff : Transformation
    {
        public override void SetStaticDefaults()
        {
            damageMulti = 4.8f;
            speedMulti = 3.5f;

            kiDrainRate = 4.5f;
            kiDrainRateWithMastery = 1.5f;

            attackDrainMulti = 1.7f;
            baseDefenceBonus = 41;

            base.SetStaticDefaults();
        }

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<OPlayer>();
            
            return !player.HasBuff<LSSJ4Buff>() && modPlayer.LSSJ4Achieved && player.GetModPlayer<GPlayer>().Trait == "Legendary";
        }
        public override void OnTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().LSSJ4Active = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<OPlayer>().LSSJ4Active = false;
        }

        public override string FormName() => "Legendary Super Saiyan 4";

        public override bool Stackable() => false;

        public override Color TextColor() => Color.HotPink;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ3", 260);
        public override AuraData AuraData() => new AuraData("oozaru/Assets/LSSJ4Aura", 4, BlendState.AlphaBlend, new Color(250, 74, 67));
        public override Gradient KiBarGradient() => new Gradient(new Color(255, 56, 99)).AddStop(1f, new Color(156, 0, 34));

        public override string HairTexturePath() => "oozaru/Assets/LSSJ4Hair";

        public override bool SaiyanSparks() => true;

    }
}
