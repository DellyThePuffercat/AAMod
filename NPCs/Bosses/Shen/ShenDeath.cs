using BaseMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Shen
{
    public class ShenDeath : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Discord's Death");
        }

        public override void SetDefaults()
        {
            npc.width = 100;
            npc.height = 100;
            npc.friendly = false;
            npc.alpha = 255;
            npc.lifeMax = 10000000;
            npc.dontTakeDamage = true;
            npc.noGravity = true;
            npc.aiStyle = -1;
            npc.timeLeft = 10;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/ChaosSissy");
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        } 

        public override void AI()
        {
            npc.ai[1]++;
            Player player = Main.player[npc.target];
            npc.TargetClosest();
            npc.Center = player.Center;
            if (npc.ai[1] == 180)
            {
                Main.NewText("Split again�", new Color(180, 41, 32));
            }

            if (npc.ai[1] == 360)
            {
                Main.NewText("This is YOUR fault you insolent worm..! I knew we should have been more aggressive but NOOOOOOOOO..! YOU said we could squash them without even trying!", new Color(45, 46, 70));
            }

            if (npc.ai[1] == 540)
            {
                Main.NewText("id, you will know our wrath again one day...when we gain enough power again�", new Color(180, 41, 32));
            }

            if (npc.ai[1] == 720)
            {
                Main.NewText("...or you decide to use that Sigil again..!", new Color(45, 46, 70));
            }

            if (npc.ai[1] >= 900)
            {
                Main.NewText("Your choice, child.", new Color(180, 41, 32));
                Main.NewText("Your choice, child.", new Color(45, 46, 70));
                npc.active = false;
            }
        }
    }
}