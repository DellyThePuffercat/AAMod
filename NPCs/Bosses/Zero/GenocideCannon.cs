using System;
using System.IO;
using BaseMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Zero
{
    [AutoloadBossHead]
    public class GenocideCannon: ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Genocide Cannon");
            Main.npcFrameCount[npc.type] = 2;
            NPCID.Sets.TechnicallyABoss[npc.type] = true;
        }

        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 70;
            npc.damage = 80;
            npc.defense = 90;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit4;
            npc.lifeMax = 37500;
            npc.noGravity = true;
            animationType = NPCID.PrimeSaw;
            npc.noTileCollide = true;
            npc.knockBackResist = 0.0f;
            npc.buffImmune[20] = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[39] = true;
            npc.lavaImmune = true;
            npc.netAlways = true;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        }

        public override bool CheckActive()
        {
            if (NPC.AnyNPCs(mod.NPCType<Zero>()))
            {
                return false;
            }
            return true;
        }


        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.Y == 0.0)
                npc.spriteDirection = npc.direction;
            ++npc.frameCounter;
            if (npc.frameCounter >= 8.0)
            {
                npc.frameCounter = 0.0;
                npc.frame.Y += frameHeight;
                if (npc.frame.Y / frameHeight >= 2)
                    npc.frame.Y = 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            bool flag = (npc.life <= 0 || (!npc.active && NPC.AnyNPCs(mod.NPCType<Zero>())));
            if (flag && Main.netMode != 1)
            {
                int ind = NPC.NewNPC((int)(npc.position.X + (double)(npc.width / 2)), (int)npc.position.Y + (npc.height / 2), mod.NPCType("TeslaHand"), npc.whoAmI, npc.ai[0], npc.ai[1], npc.ai[2], npc.ai[3], npc.target);
                Main.npc[ind].Center = npc.Center;
                Main.npc[ind].velocity = new Vector2(MathHelper.Lerp(-1f, 1f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-1f, 1f, (float)Main.rand.NextDouble()));
                Main.npc[ind].velocity *= 8f;
                Main.npc[ind].netUpdate2 = true; Main.npc[ind].netUpdate = true;
            }
        }

        public int body = -1;
        public float rotValue = -1f;
        public Vector2 pos;

        public override void AI()
        {
            npc.noGravity = true;

            if (body == -1)
            {
                int npcID = BaseAI.GetNPC(npc.Center, mod.NPCType("Zero"), 1000, null);
                if (npcID >= 0) body = npcID;
            }

            if (body == -1) return;

            NPC zero = Main.npc[body];
            if (zero == null || zero.life <= 0 || !zero.active || zero.type != mod.NPCType("Zero")) { npc.active = false; return; }

            for (int m = npc.oldPos.Length - 1; m > 0; m--)
            {
                npc.oldPos[m] = npc.oldPos[m - 1];
            }
            npc.oldPos[0] = npc.position;

            int probeNumber = ((Zero)zero.modNPC).WeaponCount;
            if (rotValue == -1f) rotValue = (npc.ai[0] % probeNumber) * ((float)Math.PI * 2f / probeNumber);
            rotValue += 0.05f;
            while (rotValue > (float)Math.PI * 2f) rotValue -= (float)Math.PI * 2f;
            npc.Center = BaseUtility.RotateVector(zero.Center, zero.Center + new Vector2(((Zero)zero.modNPC).Distance, 0f), rotValue);

            if (Main.netMode != 1) { npc.ai[2]++; }

            Player player = Main.player[zero.target];

            int aiTimerFire = Main.expertMode ? 260 : 300;

            if (npc.ai[2] == aiTimerFire)
            {
                npc.ai[2] = 0;
                if (Collision.CanHit(npc.position, npc.width, npc.height, player.Center, player.width, player.height))
                {
                    Vector2 fireTarget = npc.Center;
                    float rot = BaseUtility.RotationTo(npc.Center, player.Center);
                    fireTarget = BaseUtility.RotateVector(npc.Center, fireTarget, rot);
                    BaseAI.FireProjectile(player.Center, fireTarget, mod.ProjType("GenocideRocket"), npc.damage / 2, 0f, 4f);
                }
            }

            Vector2 vector2 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
            float num1 = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) - vector2.X;
            float num2 = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2) - vector2.Y;
            float NewRotation = (float)Math.Atan2(num2, num1) - 1.57f;
            npc.rotation = MathHelper.Lerp(npc.rotation, NewRotation, 1f / 30f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D tex = Main.npcTexture[npc.type];
            Texture2D glowTex = mod.GetTexture("Glowmasks/GenocideCannon_Glow");
            BaseDrawing.DrawAfterimage(spriteBatch, tex, 0, npc, 1, 1, 6, true, 0, 0, Color.DarkRed, npc.frame, 2);
            BaseDrawing.DrawTexture(spriteBatch, tex, 0, npc, drawColor);
            BaseDrawing.DrawTexture(spriteBatch, glowTex, 0, npc, AAColor.ZeroShield);
            return false;
        }

        public override void BossHeadRotation(ref float rotation)
        {
            rotation = npc.rotation;
        }
    }
}
