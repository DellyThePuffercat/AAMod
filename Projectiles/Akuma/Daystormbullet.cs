using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Projectiles.Akuma
{
    public class Daystormbullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daystormbullet");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.tileCollide = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.alpha = 255;
        }

        public override void AI()
        {
            if (projectile.velocity.X < 0f)
            {
                projectile.spriteDirection = -1;
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            }
            else
            {
                projectile.spriteDirection = 1;
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(-90f);
            }
            if(projectile.alpha < 150)
            for (int num165 = 0; num165 < 2; num165 ++)
            {
                float x2 = projectile.position.X + projectile.width / 2 - projectile.velocity.X / 2f * (float)num165;
				float y2 = projectile.position.Y + projectile.height / 2 - projectile.velocity.Y / 2f * (float)num165;
                int num166 = Dust.NewDust(new Vector2(projectile.position.X + projectile.width / 2, projectile.position.Y + projectile.height / 2), projectile.width, projectile.height + 5, mod.DustType("AkumaDust"), projectile.velocity.X * 0.2f,
                    projectile.velocity.Y * 0.2f, 0, default(Color), 2f);
                Main.dust[num166].alpha = projectile.alpha;
                Main.dust[num166].position.X = x2;
				Main.dust[num166].position.Y = y2;
                Main.dust[num166].velocity *= 0f;
                Main.dust[num166].noGravity = true;
            }
            float num167 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
            float num168 = projectile.localAI[0];
            if (num168 == 0f)
            {
                projectile.localAI[0] = num167;
                num168 = num167;
            }
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 25;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            float num169 = projectile.position.X;
            float num170 = projectile.position.Y;
            float num171 = 300f;
            bool flag4 = false;
            int num172 = 0;
            if (projectile.ai[1] == 0f)
            {
                int num;
                for (int num173 = 0; num173 < 200; num173 = num + 1)
                {
                    if (Main.npc[num173].CanBeChasedBy(projectile, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num173 + 1)))
                    {
                        float num174 = Main.npc[num173].position.X + (float)(Main.npc[num173].width / 2);
                        float num175 = Main.npc[num173].position.Y + (float)(Main.npc[num173].height / 2);
                        float num176 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num174) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num175);
                        if (num176 < num171 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num173].position, Main.npc[num173].width, Main.npc[num173].height))
                        {
                            num171 = num176;
                            num169 = num174;
                            num170 = num175;
                            flag4 = true;
                            num172 = num173;
                        }
                    }
                    num = num173;
                }
                if (flag4)
                {
                    projectile.ai[1] = (float)(num172 + 1);
                }
                flag4 = false;
            }
            if (projectile.ai[1] > 0f)
            {
                int num177 = (int)(projectile.ai[1] - 1f);
                if (Main.npc[num177].active && Main.npc[num177].CanBeChasedBy(projectile, true) && !Main.npc[num177].dontTakeDamage)
                {
                    float num178 = Main.npc[num177].position.X + (float)(Main.npc[num177].width / 2);
                    float num179 = Main.npc[num177].position.Y + (float)(Main.npc[num177].height / 2);
                    float num180 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num178) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num179);
                    if (num180 < 1000f)
                    {
                        flag4 = true;
                        num169 = Main.npc[num177].position.X + (float)(Main.npc[num177].width / 2);
                        num170 = Main.npc[num177].position.Y + (float)(Main.npc[num177].height / 2);
                    }
                }
                else
                {
                    projectile.ai[1] = 0f;
                }
            }
            if (!projectile.friendly)
            {
                flag4 = false;
            }
            if (flag4)
            {
                float num181 = num168;
                Vector2 vector19 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num182 = num169 - vector19.X;
                float num183 = num170 - vector19.Y;
                float num184 = (float)Math.Sqrt((double)(num182 * num182 + num183 * num183));
                num184 = num181 / num184;
                num182 *= num184;
                num183 *= num184;
                int num185 = 8;
                projectile.velocity.X = (projectile.velocity.X * (float)(num185 - 1) + num182) / (float)num185;
                projectile.velocity.Y = (projectile.velocity.Y * (float)(num185 - 1) + num183) / (float)num185;
            }
        }

        public override void Kill(int timeleft)
        {
            for (int num468 = 0; num468 < 20; num468++)
            {
                int num469 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.InfinityOverloadB>(), -projectile.velocity.X * 0.2f,
                    -projectile.velocity.Y * 0.2f, 100, new Color(86, 191, 188), 2f);
                Main.dust[num469].noGravity = true;
                Main.dust[num469].velocity *= 2f;
                num469 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.InfinityOverloadB>(), -projectile.velocity.X * 0.2f,
                    -projectile.velocity.Y * 0.2f, 100, new Color(86, 191, 188));
                Main.dust[num469].velocity *= 2f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Daybreak, 600);
        }
    }
}