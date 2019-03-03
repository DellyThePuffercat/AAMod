using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BaseMod;

namespace AAMod.NPCs.Enemies.Desert
{
    public class MiniDjinnCo : ModNPC
	{
        private bool Shooty = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Djinn");
			Main.npcFrameCount[npc.type] = 16;
		}

		public override void SetDefaults()
		{
            npc.lifeMax = 200;
            npc.defense = 20;
            npc.damage = 20;
            npc.width = 42;
            npc.height = 66;
            npc.aiStyle = -1;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.4f;
            npc.noTileCollide = true;
            npc.noGravity = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDesert && spawnInfo.player.ZoneCorrupt && !spawnInfo.player.ZoneBeach && NPC.downedBoss3 && Main.dayTime ? .1f : 0f;
        }

        public float[] shootAI = new float[4];

        public override void AI()
        {
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = -1;

            }
            else
            {
                npc.spriteDirection = 1;
            }
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            BaseAI.AIFloater(npc, ref npc.ai, true, 0.2f, 3, 1.5f, .05f, 1.3f, 4);
            npc.ai[3]++;

            if (npc.ai[3] >= 120)
            {
                FireMagic(npc, npc.velocity);
                npc.ai[3] = 0;
            }
            
            npc.frameCounter++;
            if (npc.frameCounter >= 10)
            {
                npc.frameCounter = 0;
                npc.frame.Y += 66;
                if (Shooty == true)
                {
                    if (npc.frame.Y < 66 * 8)
                    {
                        npc.frame.Y = 66 * 8;
                    }
                    if (npc.frame.Y > (66 * 15) )
                    {
                        npc.frameCounter = 0;
                        npc.frame.Y = 0;
                        Shooty = false;
                    }
                }
                else
                {
                    if (npc.frame.Y > (66 * 7))
                    {
                        npc.frameCounter = 0;
                        npc.frame.Y = 0;
                    }
                }
            }
        }

        public void FireMagic(NPC npc, Vector2 velocity)
        {
            Player player = Main.player[npc.target];
            Shooty = true;

            BaseAI.FireProjectile(player.Center, npc, 96, (int)(npc.damage * 0.25f), 0f, 2f);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                npc.position.X = npc.position.X + (float)(npc.width / 2);
                npc.position.Y = npc.position.Y + (float)(npc.height / 2);
                npc.width = 42;
                npc.height = 66;
                npc.position.X = npc.position.X - (float)(npc.width / 2);
                npc.position.Y = npc.position.Y - (float)(npc.height / 2);
                int dust1 = mod.DustType<Dusts.SandDust>();
                int dust2 = mod.DustType<Dusts.SandDust>();
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust1, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust1].velocity.X *= 0f;
                Main.dust[dust1].scale *= 1.3f;
                Main.dust[dust1].noGravity = false;
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust2, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust2].velocity.X *= 0f;
                Main.dust[dust2].scale *= 1.3f;
                Main.dust[dust2].noGravity = false;
            }
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(4) == 0)
            {
                npc.DropLoot(mod.ItemType<Items.BossSummons.DjinnLamp>());
            }
        }
    }
}