﻿using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using AAMod.Items.Tools;

namespace AAMod.UI
{
    internal sealed class TerratoolTUI : TerratoolUI
    {
        public static int Pick = 0;

        public static int Hammer = 0;

        public static int Axe = 0;

        public override Texture2D ButtonImages()
        {
            return AAMod.instance.GetTexture("UI/Tools/ToolUI");
        }

        public override Texture2D ButtonOnImage() { return AAMod.instance.GetTexture("UI/Tools/ToolButton"); }

        public override Texture2D ButtonOffImage() { return AAMod.instance.GetTexture("UI/Tools/ToolButtonOff"); }

        public override int HeldItemType() { return AAMod.instance.ItemType<Terratool>(); }

        public override UserInterface Interface() { return AAMod.instance.TerratoolInterface; }

        public override UIState State() { return AAMod.instance.TerratoolState; }

        public override void ButtonClicked(int index)
        {
            base.ButtonClicked(index);
            Pick = selectedButtons.Contains(0) ? 215 : 0;
            Hammer = selectedButtons.Contains(1) ? 120 : 0;
            Axe = selectedButtons.Contains(2) ? 50 : 0;
        }
    }
}