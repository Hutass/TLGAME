using System;
using System.Drawing;
using System.Linq;

namespace TLGAME
{
    [Serializable]
    class Interface : GhostObject
    {
        public Interface(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {

        }
        public override void ObjectMove()
        {

        }
        public override void Draw(Graphics field)
        {

        }
        public override void Erase()
        {

        }
        public void DrawESBar(Graphics field, int number)
        {
            int x = 32, y = 232;
            GraphicsUnit unit = GraphicsUnit.Pixel;
            Bitmap Bmp_Health = new Bitmap(Properties.Resources.Shield_sprite_sheet);
            Bitmap Bmp_Background = new Bitmap(24, 60);
            Graphics buf = Graphics.FromImage(Bmp_Background);
            Rectangle rect;
            for (byte i = 0; i < 14; i++)
            {
                rect = new Rectangle(0, 120, 24, 60);
                buf.DrawImage(Bmp_Health, 0, 0, rect, unit);
                if (i < number && number > 0)
                {
                    if (number > 5)
                        rect = new Rectangle(0, 0, 24, 60);
                    else
                        rect = new Rectangle(0, 60, 24, 60);
                    buf.DrawImage(Bmp_Health, 0, 0, rect, unit);
                }
                field.DrawImage(Bmp_Background, x, y);
                x += 28;
                if (i == 13)
                {
                    rect = new Rectangle(24, 120, 24, 60);
                    Bitmap Bmp_Background_b = new Bitmap(24, 60);
                    Graphics buf_b = Graphics.FromImage(Bmp_Background_b);
                    buf_b.DrawImage(Bmp_Health, 0, 0, rect, unit);
                    if (number == 15)
                    {
                        rect = new Rectangle(24, 0, 24, 60);
                        buf_b.DrawImage(Bmp_Health, 0, 0, rect, unit);
                    }
                    field.DrawImage(Bmp_Background_b, x, y);
                }
            }
        }
        public void DrawStatIcons(Graphics field)
        {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            Bitmap Bmp_Icons = new Bitmap(Properties.Resources.StatIcons_sprite_sheet);
            for (byte i = 0; i < 4; i++)
            {
                Rectangle rect = new Rectangle(i*32, 0, 32, 32);
                field.DrawImage(Bmp_Icons, 90, 900 + i * 40, rect, unit);
            }
            for (byte i = 0; i < 4; i++)
            {
                Rectangle rect = new Rectangle(128 + (i * 32), 0, 32, 32);
                field.DrawImage(Bmp_Icons, 290, 900 + i * 40, rect, unit);
            }
        }
        public void DrawHPBar(Graphics field, int number)
        {
            int x = 32, y = 316;
            GraphicsUnit unit = GraphicsUnit.Pixel;
            Bitmap Bmp_Health = new Bitmap(Properties.Resources.Health_sprite_sheet);
            Bitmap Bmp_Background = new Bitmap(24, 60);
            Graphics buf = Graphics.FromImage(Bmp_Background);
            Rectangle rect;
            for (byte i = 0; i < 14; i++)
            {
                rect = new Rectangle(0, 120, 24, 60);
                buf.DrawImage(Bmp_Health, 0, 0, rect, unit);
                if (i < number && number > 0)
                {
                    if (number > 5)
                        rect = new Rectangle(0, 0, 24, 60);
                    else
                        rect = new Rectangle(0, 60, 24, 60);
                    buf.DrawImage(Bmp_Health, 0, 0, rect, unit);
                }
                field.DrawImage(Bmp_Background, x, y);
                x += 28;
                if (i == 13)
                {
                    rect = new Rectangle(24, 120, 24, 60);
                    Bitmap Bmp_Background_b = new Bitmap(24, 60);
                    Graphics buf_b = Graphics.FromImage(Bmp_Background_b);
                    buf_b.DrawImage(Bmp_Health, 0, 0, rect, unit);
                    if (number == 15)
                    {
                        rect = new Rectangle(24, 0, 24, 60);
                        buf_b.DrawImage(Bmp_Health, 0, 0, rect, unit);
                    }
                    field.DrawImage(Bmp_Background_b, x, y);
                }
            }
        }
        public void DrawShellRight(Graphics field)
        {
            Bitmap Bmp_Background = new Bitmap(Properties.Resources.Interface);
            field.DrawImage(Bmp_Background, 0, 0);
            DrawText(field, 40, 40, Globals.TEXT_LARGE, "SCORE:");
            DrawStatIcons(field);
        }
        public void DrawShellLeft(Graphics field)
        {
            Bitmap Bmp_Background = new Bitmap(Properties.Resources.Interface2);
            field.DrawImage(Bmp_Background, 0, 0);
        }
        public void DrawText(Graphics field, int x, int y, int type, string str)
        {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            Bitmap Bmp_Sign8 = new Bitmap(Properties.Resources.Alphabet_8px);
            Bitmap Bmp_Sign16 = new Bitmap(Properties.Resources.Alphabet_16px);
            Bitmap Bmp_Sign24 = new Bitmap(Properties.Resources.Alphabet_24px);
            Bitmap Bmp_Background8 = new Bitmap(8, 12);
            Bitmap Bmp_Background16 = new Bitmap(16, 24);
            Bitmap Bmp_Background24 = new Bitmap(24, 36);
            switch (type)
            {
                case 1:
                    for (int i = 0; i < str.Length; i++)
                    {
                        Graphics buf = Graphics.FromImage(Bmp_Background8);
                        buf.Clear(Color.FromArgb(255, 16, 18, 28));
                        Rectangle rect = new Rectangle(((str.ElementAt(i) - 48) * 8), 0, 8, 12);
                        buf.DrawImage(Bmp_Sign8, 0, 0, rect, unit);
                        field.DrawImage(Bmp_Background8, x, y);
                        x += 11;
                    }
                    break;
                case 2:
                    for (int i = 0; i < str.Length; i++)
                    {
                        Graphics buf = Graphics.FromImage(Bmp_Background16);
                        buf.Clear(Color.FromArgb(255, 16, 18, 28));
                        Rectangle rect = new Rectangle(((int)(str.ElementAt(i) - 48) * 16), 0, 16, 24);
                        buf.DrawImage(Bmp_Sign16, 0, 0, rect, unit);
                        field.DrawImage(Bmp_Background16, x, y);
                        x += 21;
                    }
                    break;
                case 3:
                    for (int i = 0; i < str.Length; i++)
                    {
                        Graphics buf = Graphics.FromImage(Bmp_Background24);
                        buf.Clear(Color.FromArgb(255,16,18,28));
                        Rectangle rect = new Rectangle(((str.ElementAt(i) - 48) * 24), 0, 24, 36);
                        buf.DrawImage(Bmp_Sign24, 0, 0, rect, unit);
                        field.DrawImage(Bmp_Background24, x, y);
                        x += 29;
                    }
                    break;
            }
        }
    }
}
