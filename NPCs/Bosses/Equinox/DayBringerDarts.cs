﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Equinox
{
    public class DayBringerDarts : ModProjectile
    {
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DayBringer Darts");
		}

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.hostile = true;
            projectile.scale = 1f;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
			projectile.timeLeft = 180;
        }	
        public override void AI()
        {
			projectile.rotation = projectile.velocity.ToRotation() + 1.5707f;
            
            if (projectile.timeLeft == 0)
            {
                projectile.Kill();
            }

            int dustId = Dust.NewDust(new Vector2(projectile.Center.X + 9f, projectile.Center.Y), projectile.width, projectile.height + 10, 6, projectile.velocity.X * 0.2f,
                projectile.velocity.Y * 0.2f, 100, new Color(250, 244, 171), 2f);
            Main.dust[dustId].noGravity = true;
            int dustId3 = Dust.NewDust(new Vector2(projectile.Center.X + 9f, projectile.Center.Y), projectile.width, projectile.height + 10, 6, projectile.velocity.X * 0.2f,
                projectile.velocity.Y * 0.2f, 100, new Color(250, 244, 171), 2f);
            Main.dust[dustId3].noGravity = true;
        }

        public override void Kill(int timeLeft)
        {
            int id = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, 612, projectile.damage, 10f, projectile.owner, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);
            Main.projectile[id].hostile = true;
            Main.projectile[id].friendly = false;
        }
    }
}