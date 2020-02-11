using BaseMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace AAMod.NPCs.TownNPCs
{
    [AutoloadHead]
	public class Anubis : ModNPC
	{
        public override string Texture => "AAMod/NPCs/TownNPCs/Anubis";

        public override bool Autoload(ref string name)
        {
            name = "Legendscribe";
            return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 26;
            npc.dontTakeDamageFromHostiles = true;
			NPCID.Sets.ExtraFramesCount[npc.type] = 10;
			NPCID.Sets.AttackFrameCount[npc.type] = 5;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 40;
			NPCID.Sets.AttackAverageChance[npc.type] = 20;
			NPCID.Sets.HatOffsetY[npc.type] = 3;
		}

        public float internalAI = 0;

        public override void SendExtraAI(BinaryWriter writer)
        {
            base.SendExtraAI(writer);
            if (Main.netMode == NetmodeID.Server || Main.dedServ)
            {
                writer.Write(internalAI);
            }
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            base.ReceiveExtraAI(reader);
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                internalAI = reader.ReadFloat();
            }
        }

        public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 68;
			npc.lifeMax = 160000;
            npc.HitSound = SoundID.NPCHit23;
            npc.DeathSound = SoundID.NPCDeath39;
            npc.knockBackResist = 0f;
			animationType = NPCID.Guide;
            npc.lavaImmune = true;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        }

		public override void HitEffect(int hitDirection, double damage)
		{
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return true;
		}

		public override string TownNPCName()
		{
            return "Anubis";
        }

        public override void PostAI()
        {
        }

        public static bool SwitchInfo = false;
        public static bool DoNext = false;
        public static bool Mushroom = false;
        public static bool Glowshroom = false;
        public static bool Grips = false;
        public static bool Brood = false;
        public static bool Hydra = false;
        public static bool Djinn = false;
        public static bool Serpent = false;
        public static bool AnubisB = false;
        public static bool Rajah = false;
        public static bool Equinox = false;
        public static bool Sisters = false;
        public static bool Akuma = false;
        public static bool Yamata = false;
        public static bool Zero = false;
        public static bool RajahC = false;
        public static bool BaseChat = false;
        public static int ChatNumber = 0;

        public override void ResetEffects()
        {
            SwitchInfo = false;
            DoNext = false;
            Mushroom = false;
            Glowshroom = false;
            Grips = false;
            Brood = false;
            Hydra = false;
            Djinn = false;
            Serpent = false;
            AnubisB = false;
            Rajah = false;
            Equinox = false;
            Sisters = false;
            Akuma = false;
            Yamata = false;
            Zero = false;
            RajahC = false;
        }
        
        public override void SetChatButtons(ref string button, ref string button2)
        {
			string SwitchInfoT = Lang.TownNPCAnubis("SetChatButtons1");

            string DoNextT = Lang.TownNPCAnubis("SetChatButtons2");

            string MushT = Lang.TownNPCAnubis("SetChatButtons3");

            string GlowT = Lang.TownNPCAnubis("SetChatButtons4");

            string GripT = Lang.TownNPCAnubis("SetChatButtons5");

            string BroodT = Lang.TownNPCAnubis("SetChatButtons6");

            string HydraT = Lang.TownNPCAnubis("SetChatButtons7");

            string DjinnT = Lang.TownNPCAnubis("SetChatButtons8");

            string SerpentT = Lang.TownNPCAnubis("SetChatButtons9");

            string AnubisT = Lang.TownNPCAnubis("SetChatButtons14");

            string RajahT = Lang.TownNPCAnubis("SetChatButtons23");

            string EquinoxT = Lang.TownNPCAnubis("SetChatButtons13");

            string SistersT = Lang.TownNPCAnubis("SetChatButtons15");

            string AkumaT = Lang.TownNPCAnubis("SetChatButtons16");

            string YamataT = Lang.TownNPCAnubis("SetChatButtons17");

            string ZeroT = Lang.TownNPCAnubis("SetChatButtons18");

            string RajahCT = Lang.TownNPCAnubis("SetChatButtons26");
            
            button = SwitchInfoT;

            if (ChatNumber == 0)
			{
			    button2 = DoNextT;
                DoNext = true;
            }
            else if (ChatNumber == 1)
            {
                button2 = MushT;
                Mushroom = true;
            }
            else if (ChatNumber == 2)
            {
                button2 = GlowT;
                Glowshroom = true;
            }
            else if (ChatNumber == 3)
            {
                button2 = GripT;
                Grips = true;
            }
            else if (ChatNumber == 4)
            {
                button2 = BroodT;
                Brood = true;
            }
            else if (ChatNumber == 5)
            {
                button2 = HydraT;
                Hydra = true;
            }
            else if (ChatNumber == 6 && NPC.downedBoss3)
            {
                button2 = DjinnT;
                Djinn = true;
            }
            else if (ChatNumber == 7 && NPC.downedBoss3)
            {
                button2 = SerpentT;
                Serpent = true;
            }
            else if (ChatNumber == 8 && NPC.downedPlantBoss)
            {
                button2 = AnubisT;
                AnubisB = true;
            }
            else if (ChatNumber == 9 && Main.hardMode)
            {
                button2 = RajahT;
                Rajah = true;
            }
            else if (ChatNumber == 10 && AAWorld.downedGreedA && AAWorld.downedAthenaA)
            {
                button2 = EquinoxT;
                Equinox = true;
            }
            else if (ChatNumber == 11 && NPC.downedMoonlord && AAWorld.downedEquinox)
            {
                button2 = SistersT;
                Sisters = true;
            }
            else if (ChatNumber == 12 && NPC.downedMoonlord && AAWorld.downedSisters)
            {
                button2 = AkumaT;
                Akuma = true;
            }
            else if (ChatNumber == 13 && NPC.downedMoonlord && AAWorld.downedSisters)
            {
                button2 = YamataT;
                Yamata = true;
            }
            else if (ChatNumber == 14 && NPC.downedMoonlord && AAWorld.downedNC)
            {
                button2 = ZeroT;
                Zero = true;
            }
            else if (ChatNumber == 25 && AAWorld.downedRajahsRevenge)
            {
                button2 = RajahCT;
                RajahC = true;
            }
            else
            {
                ChatNumber = 0;
                button2 = DoNextT;
                DoNext = true;
            }
        }

        public void ResetBools()
        {
            DoNext = false;
            Mushroom = false;
            Glowshroom = false;
            Grips = false;
            Brood = false;
            Hydra = false;
            Djinn = false;
            Serpent = false;
            AnubisB = false;
            Rajah = false;
            Equinox = false;
            Sisters = false;
            Akuma = false;
            Yamata = false;
            Zero = false;
            RajahC = false;
        }

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				ResetBools();
				ChatNumber += 1;
				if (ChatNumber > 23)
				{
					ChatNumber = 0;
				}
			}
			else
            {
                Main.npcChatText = BossChat();
			}
		}

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D t = mod.GetTexture(AAWorld.downedAnubisA ? "NPCs/TownNPCs/AnubisF" : "NPCs/TownNPCs/Anubis");
            Texture2D g = mod.GetTexture(AAWorld.downedAnubisA ? "Glowmasks/AnubisF_Glow" : "Glowmasks/Anubis_Glow");
            BaseDrawing.DrawTexture(spriteBatch, t, 0, npc, drawColor);
            BaseDrawing.DrawTexture(spriteBatch, g, 0, npc, Color.White);
            return false;
        }

        public static bool DoG => (bool)ModSupport.GetModWorldConditions("CalamityMod", "CalamityWorld", "downedDoG", false, true);

        public static string BossChat()
        {
            Player player = Main.LocalPlayer;
            if (Mushroom)
            {
                return AAWorld.downedMonarch ? Lang.TownNPCAnubis("downedMonarchY") : 
                    Lang.TownNPCAnubis("downedMonarchN");
            }
            else if (Glowshroom)
            {
                return AAWorld.downedFungus ? Lang.TownNPCAnubis("downedFungusY") : 
                    Lang.TownNPCAnubis("downedFungusN");
            }
            else if (Grips)
            {
                return AAWorld.downedGrips ? Lang.TownNPCAnubis("downedGripsY") : 
                    Lang.TownNPCAnubis("downedGripsN");
            }
            else if (Brood)
            {
                return AAWorld.downedBrood ? Lang.TownNPCAnubis("downedBroodY") :
                    Lang.TownNPCAnubis("downedBroodN");
            }
            else if (Hydra)
            {
                return AAWorld.downedHydra ? Lang.TownNPCAnubis("downedHydraY") : 
                    Lang.TownNPCAnubis("downedHydraN");
            }
            else if (Djinn)
            {
                return AAWorld.downedDjinn ? Lang.TownNPCAnubis("downedDjinnY") : 
                    Lang.TownNPCAnubis("downedDjinnN");
            }
            else if (Serpent)
            {
                return AAWorld.downedSerpent ? Lang.TownNPCAnubis("downedSerpentY") : 
                    Lang.TownNPCAnubis("downedSerpentN");
            }
            else if (Rajah)
            {
                return AAWorld.downedRajah ? Lang.TownNPCAnubis("downedRajahY") :
                    Lang.TownNPCAnubis("downedRajahN");
            }
            else if (Equinox)
            {
                return AAWorld.downedEquinox ? Lang.TownNPCAnubis("downedEquinoxY") : 
                    Lang.TownNPCAnubis("downedEquinoxN");
            }
            else if (Sisters)
            {
                return AAWorld.downedSisters ? Lang.TownNPCAnubis("downedSistersY") : 
                    Lang.TownNPCAnubis("downedSistersN");
            }
            else if (Akuma)
            {
                return AAWorld.downedAkuma ? Lang.TownNPCAnubis("downedAkumaY") : 
                    Lang.TownNPCAnubis("downedAkumaN");
            }
            else if (Yamata)
            {
                return AAWorld.downedYamata ? Lang.TownNPCAnubis("downedYamataY") :
                    Lang.TownNPCAnubis("downedYamataN");
            }
            else if (Zero)
            {
                return AAWorld.downedZero ? Lang.TownNPCAnubis("downedZeroY") : 
                    Lang.TownNPCAnubis("downedZeroN");
            }
            else if (RajahC)
            {
                return AAWorld.downedShen ?  Lang.TownNPCAnubis("downedRajahCY") :
                    Lang.TownNPCAnubis("downedRajahCN");
            }
            else
            {
                return GuideChat();
            }
        }

        public static string GuideChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            if (!AAWorld.downedYamata)
            {
                chat.Add(Lang.TownNPCAnubis("AkumaGuideChat"));
            }

            if (!AAWorld.downedAkuma)
            {
                chat.Add(Lang.TownNPCAnubis("YamataGuideChat"));
            }
            if (Main.rand.Next(2) == 0)
            {
                chat.Add(Lang.TownNPCAnubis("BroodMotherGuideChat"));
            }
            else
            {
                chat.Add(Lang.TownNPCAnubis("HydraGuideChat"));
            }
            chat.Add(Lang.TownNPCAnubis("VoidGuideChat"));
            if (Main.hardMode)
            {
                chat.Add(Lang.TownNPCAnubis("HardModeGuideChat1"));
                chat.Add(Lang.TownNPCAnubis("HardModeGuideChat2"));
            }

            if (AAWorld.downedEquinox)
            {
                chat.Add(Lang.TownNPCAnubis("EquinoxBossGuideChat"));
            }
            return chat;
        }

        public override string GetChat()
        {
            Mod GRealm = ModSupport.GetMod("Grealm");
            Mod Fargos = ModSupport.GetMod("Fargowiltas");
            Mod Redemption = ModSupport.GetMod("Redemption");
            Mod Thorium = ModSupport.GetMod("ThoriumMod");

            int HordeZombie = GRealm == null ? -1 : NPC.FindFirstNPC(ModSupport.GetModNPC("GRealm", "HordeZombie").npc.type);
            int Mutant = Fargos == null ? -1 : NPC.FindFirstNPC(ModSupport.GetModNPC("Fargowiltas", "Mutant").npc.type);
            int Newb = Redemption == null ? -1 : NPC.FindFirstNPC(ModSupport.GetModNPC("Redemption", "Newb").npc.type);
            int Cobbler = Thorium == null ? -1 : NPC.FindFirstNPC(ModSupport.GetModNPC("ThoriumMod", "Cobbler").npc.type);
            int ConfusedZombie = Thorium == null ? -1 : NPC.FindFirstNPC(ModSupport.GetModNPC("ThoriumMod", "ConfusedZombie").npc.type);

            WeightedRandom<string> chat = new WeightedRandom<string>();

            Player player = Main.LocalPlayer;

            chat.Add(Lang.TownNPCAnubis("AnubisChat1"));
            chat.Add(Lang.TownNPCAnubis("AnubisChat2"));
            chat.Add(Lang.TownNPCAnubis("AnubisChat3"));
            chat.Add(Lang.TownNPCAnubis("AnubisChat4"));
            chat.Add(Lang.TownNPCAnubis("AnubisChat5"));
            chat.Add(Lang.TownNPCAnubis("AnubisChat6"));
            chat.Add(Lang.TownNPCAnubis("AnubisChat7"));
            if (AAWorld.downedDjinn)
            {
                chat.Add(Lang.TownNPCAnubis("AnubisChat8"));
            }
            chat.Add(Lang.TownNPCAnubis("AnubisChat9"));
            chat.Add(Lang.TownNPCAnubis("AnubisChat10"));
            chat.Add(Lang.TownNPCAnubis("AnubisChat11") + (WorldGen.crimson ? Lang.TownNPCAnubis("AnubisChat12") : Lang.TownNPCAnubis("AnubisChat13")) + Lang.TownNPCAnubis("AnubisChat14"));
            chat.Add(Lang.TownNPCAnubis("AnubisChat15"));
            


            int FemaleNPC = NPC.FindFirstNPC(FindFemaleNPC());


            if (Main.bloodMoon && FemaleNPC != NPCID.PartyGirl)
            {
                chat.Add(Lang.TownNPCAnubis("AnubisChat16") + Main.npc[FemaleNPC].GivenName + Lang.TownNPCAnubis("AnubisChat17"));
            }
            else if (Main.bloodMoon && FemaleNPC == NPCID.PartyGirl)
            {
                chat.Add(Lang.TownNPCAnubis("AnubisChat18") + Main.npc[FemaleNPC].GivenName + Lang.TownNPCAnubis("AnubisChat19"));
            }

            if (player.head == 200 && player.body == 198 && player.legs == 142)
            {
                chat.Add(Lang.TownNPCAnubis("AnubisChat20"));
            }

            if (BirthdayParty.GenuineParty || BirthdayParty.ManualParty)
            {
                chat.Add(Lang.TownNPCAnubis("AnubisChat21"));
            }

            if (HordeZombie >= 0)
            {
                chat.Add(Lang.TownNPCAnubis("AnubisChat23") + Main.npc[HordeZombie].GivenName + Lang.TownNPCAnubis("AnubisChat24"));
            }

            if (Mutant >= 0)
            {
                chat.Add(Lang.TownNPCAnubis("AnubisChat25") + Main.npc[Mutant].GivenName + Lang.TownNPCAnubis("AnubisChat26"));
            }

            if (Newb >= 0)
            {
                chat.Add(Lang.TownNPCAnubis("AnubisChat27") + Main.npc[Newb].GivenName + Lang.TownNPCAnubis("AnubisChat28"));
            }

            if (Cobbler >= 0)
            {
                chat.Add(Main.npc[Cobbler].GivenName + Lang.TownNPCAnubis("AnubisChat29"));
            }

            if (ConfusedZombie >= 0)
            {
                chat.Add(Lang.TownNPCAnubis("AnubisChat30") + Main.npc[ConfusedZombie].GivenName + Lang.TownNPCAnubis("AnubisChat31"));
            }

            return chat;
        }

        public static string WHATTHEFUCKDOIDOANUBIS()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            
            return chat;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 30;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 20;
			randExtraCooldown = 20;
		}

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<JudgementNPC>();
            attackDelay = 5;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {

            multiplier = 4f;

            randomOffset = 2f;

        }

        public int FindFemaleNPC()
        {
            int FemaleNPC = Main.rand.Next(6);
            switch (FemaleNPC)
            {
                case 0:
                    FemaleNPC = NPCID.Nurse;
                    break;
                case 1:
                    FemaleNPC = NPCID.Dryad;
                    break;
                case 2:
                    FemaleNPC = NPCID.Stylist;
                    break;
                case 3:
                    FemaleNPC = NPCID.Mechanic;
                    break;
                case 4:
                    FemaleNPC = NPCID.Steampunker;
                    break;
                default:
                    FemaleNPC = NPCID.PartyGirl;
                    break;
            }
            return FemaleNPC;
        }
    }
}