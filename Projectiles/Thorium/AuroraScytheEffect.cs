using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using BaseMod;
using AAMod;

namespace AAMod.Projectiles.Thorium
{
    public class AuroraScytheEffect : ModProjectile
    {
        public static Color lightColor = new Color(41, 60, 103);
		

		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = -1;
			projectile.tileCollide = false;projectile.ownerHitCheck = true;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 24;
		}

		public static Vector2 RotateVector(Vector2 origin, Vector2 vecToRot, float rot)
        {
            float newPosX = (float)(Math.Cos(rot) * (vecToRot.X - origin.X) - Math.Sin(rot) * (vecToRot.Y - origin.Y) + origin.X);
            float newPosY = (float)(Math.Sin(rot) * (vecToRot.X - origin.X) + Math.Cos(rot) * (vecToRot.Y - origin.Y) + origin.Y);
            return new Vector2(newPosX, newPosY);
        }

		public Vector2 rotVec = new Vector2(0, 65);
		public float rot = 0f;

		public override void AI()
		{
			Player player = Main.player[projectile.owner];	
			
			if (player.direction > 0)
			{
				rot += 0.20f;
			}
			else
			{
				rot -= 0.20f;
			}

			projectile.Center = player.Center + new Vector2(-8f, -8f) + RotateVector(default(Vector2), rotVec, rot + (projectile.ai[0] * (6.28f / 2)));

			for (int m = 0; m < 5; m++)
            {
                float velX = projectile.velocity.X / 3f * (float)m;
                float velY = projectile.velocity.Y / 3f * (float)m;
				int dustID = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<Dusts.IceDust>(), 0, 0, 0, default(Color), 1f);				
                //int dustID = Dust.NewDust(projectile.position, projectile.width, projectile.height, 55, 0f, 0f, 0, default(Color), 1.2f);
                Main.dust[dustID].position.X = projectile.Center.X - velX;
                Main.dust[dustID].position.Y = projectile.Center.Y - velY;
                Main.dust[dustID].velocity *= 0f;
				Main.dust[dustID].alpha = 180;				
				Main.dust[dustID].noGravity = true;
                Main.dust[dustID].scale = 0.8f;
            }
		}
	}
}