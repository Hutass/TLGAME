using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TLGAME
{
    public delegate void PlayerEvents(Player player);
    public delegate void MenuEvents();
    [Serializable]
    public class Player : SolidObject
    {       
        private double vx = 0, vy = 0;
        private int sideTick = 0, fireTick = 0, shieldRecoverTick = 0, invulnerabilityTick = 0, invulnerabilitBuf = 0, health = 0, shield = 0, score = 0, coin = 0;
        private bool[] keyDown = new bool[5], keyDownBuf = new bool[4];
        private bool weaponTrig = false;
        public Cannon cannon;
        public /*virtual*/ event PlayerEvents PlayerCollide;
        public /*virtual*/ event PlayerEvents PlayerDeath;
        public /*virtual*/ event PlayerEvents PlayerMove;
        public /*virtual*/ event MenuEvents PauseGame;
        public /*virtual*/ event MenuEvents GameHint;
        public /*virtual*/ event MenuEvents Credits;

        public Player(double x = 0, double y = 0) : base(x, y)
        {

        }
        public bool WeaponTrig { get => weaponTrig; set => weaponTrig = value; }
        public double VX { get => vx; set => vx = value; }
        public double VY { get => vy; set => vy = value; }
        public int Health { get => health; set => health = value; }
        public int Shield { get => shield; set => shield = value; }
        public int Score { get => score; set => score = value; }
        public int Coin { get => score; set => score = value; }
        public int Invulnerability { get => invulnerabilityTick; set => invulnerabilityTick = value; }
        public int ShieldRecover { get => shieldRecoverTick; set => shieldRecoverTick = value; }
        public void Behavior(Graphics field)
        {
            Fire();
            Collide();
            ObjectMove();
            Draw(field);
            if (invulnerabilityTick > 0)
                invulnerabilityTick--;
            if (shieldRecoverTick > 0)
                shieldRecoverTick--;
            if (health <= 0)
                PlayerDeath?.Invoke(this);
        }
        public override void Draw(Graphics field)
        {
            Bitmap Bmp_Player = new Bitmap(Properties.Resources.Player_Sprite_Sheet);
            Rectangle rect;
            if (sideTick < Globals.UPDATE_TIME)
            {
                rect = new Rectangle(0, 0, 64, 64);
                if (sideTick < 2 * Globals.UPDATE_TIME)
                    sideTick++;
            }
            else
                if (keyDown[1])
            {
                rect = new Rectangle(((sideTick / Globals.UPDATE_TIME) * 64) % 256, 128, 64, 64);
                //if (sideTick < 2 * Globals.UPDATE_TIME)
                sideTick++;
            }
            else
                    if (keyDown[0])
            {
                rect = new Rectangle(((sideTick / Globals.UPDATE_TIME) * 64) % 256, 192, 64, 64);
                //if (sideTick < 2 * Globals.UPDATE_TIME)
                sideTick++;
            }
            else
            {
                rect = new Rectangle(((sideTick / Globals.UPDATE_TIME) * 64) % 256, 64, 64, 64);
                //if (sideTick < 2 * Globals.UPDATE_TIME)
                sideTick++;

            }

            GraphicsUnit unit = GraphicsUnit.Pixel;
            if (invulnerabilityTick == 0)
                field.DrawImage(Bmp_Player, Convert.ToInt32(x), Convert.ToInt32(y), rect, unit);
            else
                if (invulnerabilitBuf > -15)
            {
                invulnerabilitBuf--;
                if (invulnerabilitBuf <= 0)
                    field.DrawImage(Bmp_Player, Convert.ToInt32(x), Convert.ToInt32(y), rect, unit);
            }
            else
                invulnerabilitBuf = invulnerabilityTick / 6;


        }
        public override void Erase()
        {

        }
        public void Collide()
        {
            PlayerCollide?.Invoke(this);
        }
        public override void Collision(int xc1, int xc2, int yc1, int yc2)
        {

        }
        public void KeyDownEvent(object sender, KeyEventArgs e)
        {
            string buf_string = e.KeyCode.ToString();
            if (buf_string.Equals("A")) { keyDown[0] = true; if (keyDown[1]) { keyDown[1] = false; keyDownBuf[1] = true; sideTick = 0; } }
            if (buf_string.Equals("D")) { keyDown[1] = true; if (keyDown[0]) { keyDown[0] = false; keyDownBuf[0] = true; sideTick = 0; } }
            if (buf_string.Equals("W")) { keyDown[2] = true; if (keyDown[3]) { keyDown[3] = false; keyDownBuf[3] = true; } }
            if (buf_string.Equals("S")) { keyDown[3] = true; if (keyDown[2]) { keyDown[2] = false; keyDownBuf[2] = true; } }
            if (buf_string.Equals("Space")) { keyDown[4] = true; }
            if (buf_string.Equals("Escape")) { PauseGame?.Invoke(); }
            if (buf_string.Equals("F1")) { GameHint?.Invoke(); }
            if (buf_string.Equals("F2")) { Credits?.Invoke(); }
            if (buf_string.Equals("Q")) { cannon = (Cannon)Globals.CANNON_BOLTER_TYPE; weaponTrig = true; }
            if (buf_string.Equals("E")) { cannon = (Cannon)Globals.CANNON_SHOTGUN_TYPE; weaponTrig = true; }
        }
        public void KeyUpEvent(object sender, KeyEventArgs e)
        {
            string buf_string = e.KeyCode.ToString();
            if (buf_string.Equals("A")) { keyDown[0] = false; keyDownBuf[0] = false; if (keyDownBuf[1]) { keyDownBuf[1] = false; keyDown[1] = true; sideTick = 0; } }
            if (buf_string.Equals("D")) { keyDown[1] = false; keyDownBuf[1] = false; if (keyDownBuf[0]) { keyDownBuf[0] = false; keyDown[0] = true; sideTick = 0; } }
            if (buf_string.Equals("W")) { keyDown[2] = false; keyDownBuf[2] = false; if (keyDownBuf[3]) { keyDownBuf[3] = false; keyDown[3] = true; sideTick = 0; } }
            if (buf_string.Equals("S")) { keyDown[3] = false; keyDownBuf[3] = false; if (keyDownBuf[2]) { keyDownBuf[2] = false; keyDown[2] = true; sideTick = 0; } }
            if (buf_string.Equals("Space")) { keyDown[4] = false; }
        }
        public void ObjectMove()
        {
            x += Convert.ToDouble(keyDown[0]) * (-vx) + Convert.ToDouble(keyDown[1]) * (vx);
            y += Convert.ToDouble(keyDown[3]) * (vy) + Convert.ToDouble(keyDown[2]) * (-vy);
            PlayerMove?.Invoke(this);
        }
       
        public override void Init(double x, double y)
        {
            this.x = x;
            this.y = y;
            vx = Globals.PLAYER_SPEED_VX;
            vy = Globals.PLAYER_SPEED_VY;
            health = Globals.PLAYER_MAX_HEALTH;
            shield = Globals.PLAYER_MAX_SHIELD;
            this.cannon = (Cannon)Globals.CANNON_BOLTER_TYPE;
            //cannon = (Cannon)Globals.CANNON_SHOTGUN_TYPE;
        }
        public void TakeDamage(int damage)
        {
            if (damage <= shield)
                shield -= damage;
            else
            { 
                health -= damage - shield;
                shield = 0;
            }
            shieldRecoverTick = Globals.PLAYER_SHIELD_RECOVER_TIME;
        }
        public void Fire()
        {
            if (keyDown[4] == true)
                if (fireTick == 0)
                {
                    cannon.Fire();
                    fireTick = cannon.Reload;
                }
            if (fireTick > 0)
                fireTick--;
        }
        public override Rectangle Rectangle()
        {
            return new Rectangle((int)x, (int)y, 64, 64);
        }
    }
}

