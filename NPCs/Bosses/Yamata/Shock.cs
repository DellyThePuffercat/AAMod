using Terraria;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Yamata
{
    public class Shock : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shockwave");     //The English name of the projectile
            Main.projFrames[projectile.type] = 6;     //The recording mode
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 102;
            projectile.penetrate = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
        }

        public override void AI()
        {
            if (++projectile.frameCounter >= 6)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 6)
                {
                    projectile.Kill();

                }
            }
            projectile.velocity.X *= 0.00f;
            projectile.velocity.Y *= 0.00f;

        }

        public override void Kill(int timeLeft)
        {
            projectile.timeLeft = 0;
        }

    }
}
