﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Equinox
{
    [AutoloadBossHead]		
	public class NightcrawlerHead : DaybringerHead
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightcrawler");
            Main.npcFrameCount[npc.type] = 1;
		}		
		
		public override void SetDefaults()
		{
            base.SetDefaults();
			nightcrawler = true;
		}
    }
}