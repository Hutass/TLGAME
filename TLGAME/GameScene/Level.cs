using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TLGAME
{
    [Serializable]
    class Level : BaseObject
    {
        //protected ObservableCollection<Enemy> enemies;
        //protected List<Enemy> enemies;
        //protected EnhancedList<Enemy> enemies;
        protected BindingList<Enemy> enemies;
        protected List<Projectile> enemyProjectiles;
        protected List<Projectile> playerProjectiles;
        protected List<Visuals> visuals;
        protected List<GameEvent> events;
        protected Player player;
        protected Interface inter;
        private bool exist = false;
        private int tick = 0, event_reload = 1000, iterCount = 0;
        //private System.Windows.Forms.Label label1;
        private readonly Random rand = new Random();
        public /*virtual*/ event MenuEvents PauseGame;
        public /*virtual*/ event MenuEvents Credits;
        public /*virtual*/ event MenuEvents GameHint;
        public Level(double x = 0, double y = 0) : base(x, y)
        {

        }

        public bool  Exist { get => exist; set => exist = value; }
        public void LevelStart()
        {
            //enemies = new ObservableCollection<Enemy>();
            enemies = new BindingList<Enemy>();
            //enemies = new EnhancedList<Enemy>();
            enemyProjectiles = new List<Projectile>();
            playerProjectiles = new List<Projectile>();
            visuals = new List<Visuals>();
            events = new List<GameEvent>();
            inter = new Interface();
            player = new Player();
            player.Init(400, 400);
            exist = true;
            //player.cannon.cannonFire += CreateObject;
            player.PlayerCollide += CheckCollision;
            player.PlayerDeath += DeleteObject;
            player.PauseGame += MenuOpen;
            player.Credits += Credit;
            player.GameHint += HintOpen;
            CreateEnemy();
        }
        public void InterfaceStart(Graphics right, Graphics left)
        {
            inter.DrawShellLeft(left);
            inter.DrawShellRight(right);
            inter.DrawHPBar(right, 15);
            inter.DrawESBar(right, 15);
            UpdateStat(right);
            UpdateChat(left);
        }

            public void LevelIter(Graphics g)
        {
            for (int i = events.Count() - 1; i >= 0; i--)
            {
                events[i].Behavior(g);
            }
            for (int i = playerProjectiles.Count() - 1; i >= 0; i--)
            {
                playerProjectiles[i].Behavior(g);
            }
            player.Behavior(g);
            iterCount = enemies.Count()-1;
            for (int i = enemies.Count() - 1; i >= 0; i--)
            {
                iterCount--;
                enemies[i].Behavior(g);
            }
            for (int i = enemyProjectiles.Count() - 1; i >= 0; i--)
            {
                enemyProjectiles[i].Behavior(g);
            }
            for (int i = visuals.Count() - 1; i >= 0; i--)
            {
                visuals[i].SetPlayerCords(player.X, player.Y);
                visuals[i].Behavior(g);
            }
            if (tick % 200 == 0)
                if (enemies.Count < 3)
                    CreateEnemy();
            if (tick % 350 == 0)
                CreateEvent();
            if (tick % Globals.SCORE_REWARD_TIME == 0)
                player.Score++;
            if (tick % Globals.PLAYER_SHIELD_RECOVER_SPEED == 0 && player.ShieldRecover == 0 && player.Shield != Globals.PLAYER_MAX_SHIELD)
                player.Shield += Globals.PLAYER_SHIELD_RECOVER_AMOUNT;
            if (player.cannon.FireTick == 0)
            {
                player.cannon.FireTick = 1;
                player.cannon.CannonFire += CreateObject;
            }
            if (event_reload > 0)
                event_reload--;
            tick++;
        }
        public void InterfaceIter(Graphics g)
        {
            if(player.Score <= 1)
                inter.DrawText(g, 214, 40, Globals.TEXT_LARGE, "      ");
            inter.DrawText(g, 214, 40, Globals.TEXT_LARGE, Convert.ToString(player.Score));
            if (player.Invulnerability > Globals.PLAYER_INVULNERABILITY_TIME - Globals.INTERFACE_UPDATE_TIME || player.Score < 5)
            {
                inter.DrawHPBar(g, (int)(player.Health / ((float)Globals.PLAYER_MAX_HEALTH / 15)));
            }
                inter.DrawESBar(g, (int)(player.Shield / ((float)Globals.PLAYER_MAX_SHIELD / 15)));
            if(player.WeaponTrig == true)
            {
                UpdateStat(g);
                player.WeaponTrig = false;
            }
        }
        public void ChatIter(Graphics g)
        {
            UpdateChat(g);
        }
        public override void Draw(Graphics field)
        {

        }
        public override void Erase()
        {

        }
        public void GiveReward(Enemy enemy)
        {
            player.Coin += enemy.Coin;
            player.Score += enemy.Score;
        }
        public void UpdateStat(Graphics field)
        {
            inter.DrawText(field, 140, 905, Globals.TEXT_MEDIUM, Convert.ToString(player.cannon.Damage));
            inter.DrawText(field, 140, 945, Globals.TEXT_MEDIUM, Convert.ToString(player.cannon.Reload));
            inter.DrawText(field, 140, 985, Globals.TEXT_MEDIUM, string.Concat(Convert.ToString(player.cannon.Accuracy)," "));
            inter.DrawText(field, 140, 1025, Globals.TEXT_MEDIUM, Convert.ToString(-player.cannon.VY + Globals.BULLET_SPEED_VY));
            inter.DrawText(field, 340, 905, Globals.TEXT_MEDIUM, Convert.ToString((player.VX + player.VY)/2));
            inter.DrawText(field, 340, 945, Globals.TEXT_MEDIUM, Convert.ToString(Globals.PLAYER_MAX_SHIELD));
            inter.DrawText(field, 340, 985, Globals.TEXT_MEDIUM, Convert.ToString(Globals.PLAYER_MAX_HEALTH));
            inter.DrawText(field, 340, 1025, Globals.TEXT_MEDIUM, Convert.ToString(1));
        }
        public void UpdateChat(Graphics field)
        {
            int x = 50, y = 80;
            for (int i = events.Count() - 1; i >= 0; i--)
                switch(events[i])
                {
                    case DarkSpaceEvent dse:          
                        if (dse.Time > Globals.DARK_SPACE_TIME - 100)
                        {
                            inter.DrawText(field, x, y, Globals.TEXT_MEDIUM, "YOU HAVE ENTERED   "); y += 30;
                            inter.DrawText(field, x, y, Globals.TEXT_MEDIUM, "THE DARK SECTOR    "); y += 50;
                        }
                        else
                        if (dse.Time > Globals.DARK_SPACE_TIME * 0.1)
                        {
                            inter.DrawText(field, x, y, Globals.TEXT_MEDIUM, "WAIT,THERE WILL    "); y += 30;
                            inter.DrawText(field, x, y, Globals.TEXT_MEDIUM, "BE LIGHT SOON      "); y += 50;
                        }
                        else
                            inter.DrawText(field, x, y, Globals.TEXT_MEDIUM, "DARKNESS DISSIPATES"); y += 30;
                            inter.DrawText(field, x, y, Globals.TEXT_MEDIUM, "                   "); y += 50;

                        break;
                    case BarrageEvent be:
                        if (be.Time > Globals.BARRAGE_TIME * 0.1)
                        {
                            inter.DrawText(field, x, y, Globals.TEXT_MEDIUM, "BARRAGE INCOMING   "); y += 30;
                            inter.DrawText(field, x, y, Globals.TEXT_MEDIUM, "                   "); y += 50;
                        }
                        else
                        {
                            inter.DrawText(field, x, y, Globals.TEXT_MEDIUM, "THE GUNS ARE       "); y += 30;
                            inter.DrawText(field, x, y, Globals.TEXT_MEDIUM, "RELOADING          "); y += 50;
                        }
                        break;
                }
        }
        public void CheckCollision(Object obj)
        {
            switch (obj)
            {
                case Player pl:
                    for (int i = enemyProjectiles.Count() - 1; i >= 0; i--)
                    {
                        if (pl.Rectangle().IntersectsWith(enemyProjectiles[i].Rectangle()))
                        {
                            if (pl.Invulnerability == 0)
                            {
                                pl.TakeDamage(enemyProjectiles[i].Damage);
                                pl.Invulnerability = Globals.PLAYER_INVULNERABILITY_TIME;
                            }
                            if (typeof(ProjectileRay).Equals(enemyProjectiles[i]))
                            {
                                enemyProjectiles[i].ProjectileDelete -= DeleteObject;
                                enemyProjectiles.Remove(enemyProjectiles[i]);
                            }
                        }
                    }
                    for (int i = enemies.Count() - 1; i >= 0; i--)
                    {
                        if (pl.Rectangle().IntersectsWith(enemies[i].Rectangle()))
                        {
                            if (pl.Invulnerability == 0)
                            {
                                pl.TakeDamage(1+(int)(enemies[i].Vel*2));
                                pl.Invulnerability = Globals.PLAYER_INVULNERABILITY_TIME;
                                enemies[i].Health -= (int)(player.VX + player.VY);
                                enemies[i].X += (-(player.X + 32) + (enemies[i].X + 32)) / 4;
                                enemies[i].Y += (-(player.Y + 32) + (enemies[i].Y + 32)) / 4;
                                player.X += (-(enemies[i].X + 32) + (player.X + 32 + 32)) / 5;
                                player.Y += (-(enemies[i].Y + 32) + (player.Y + 32 + 32)) / 5;
                            }
                        }
                    }
                    break;
                case Enemy en:
                    for (int i = playerProjectiles.Count() - 1; i >= 0; i--)
                    {
                        if (en.Rectangle().IntersectsWith(playerProjectiles[i].Rectangle()))
                        {
                            en.Health -= playerProjectiles[i].Damage;
                            playerProjectiles[i].ProjectileDelete -= DeleteObject;
                            playerProjectiles.Remove(playerProjectiles[i]);

                        }
                    }
                    for (int i = iterCount; i >= 0; i--)
                    {
                        if(en.Rectangle().IntersectsWith(enemies[i].Rectangle()))
                        {
                            en.StopTrig = true; enemies[i].StopTrig = true;
                            if (en.X < enemies[i].X)
                            {
                                en.X -= en.VX / 2;
                                enemies[i].X += enemies[i].VX / 2;
                            }
                            else
                            {
                                en.X += en.VX / 2;
                                enemies[i].X -= enemies[i].VX/2;
                            }
                        }
                    }
                    break;
            }
        }
        public void KeyDown(object sender, KeyEventArgs e)
        {
            player.KeyDownEvent(sender, e);
        }
        public void KeyUp(object sender, KeyEventArgs e)
        {
            player.KeyUpEvent(sender, e);
        }
        public void CreateEnemy()
        {
            while (true)
            {
                if (enemies.Count() < 4)
                {
                    enemies.Add(new EnemySniper());
                    enemies.Last().SetRandomSeed(rand);
                    enemies.Last().EnemyFire += CreateObject;
                    enemies.Last().EnemyDeath += DeleteObject;
                    enemies.Last().EnemyColide += CheckCollision;
                    enemies.Last().EnemyDeath += GiveReward;
                    player.PlayerMove += enemies.Last().GetTargetCoords;
                }
                else
                    break;
            }
        }

        public void CreateEvent()
        {
            if(event_reload == 0)
            {
                switch(rand.Next(1,3))
                {
                    case 1:
                        events.Add(new BarrageEvent());
                        event_reload += Globals.BARRAGE_TIME + 10;
                        break;
                    case 2:
                        events.Add(new DarkSpaceEvent());
                        event_reload += Globals.DARK_SPACE_TIME + 10;
                        break;
                }
                events.Last().CreateEvent += CreateObject;
                events.Last().DeleteEvent += DeleteObject;
                events.Last().CreateNewEvent();
            }
        }

        public void CreateObject(Object obj)
        {
            switch (obj)
            {
                case BarrageEvent be:
                    enemyProjectiles.Add(new ProjectileWave());
                    enemyProjectiles.Last().ProjectileDelete += DeleteObject;
                    x = rand.Next(100, 800);
                    double vx =  (rand.NextDouble() / Globals.BARRAGE_ACCURACY - 1 / (2 * Globals.BARRAGE_ACCURACY));
                    enemyProjectiles.Last().Init(x, 0, vx, -3, Globals.BARRAGE_DAMAGE);
                    break;
                case DarkSpaceEvent dse:
                    visuals.Add(new Visual_View_Area());
                    visuals.Last().VisualDelete += DeleteObject;
                    visuals.Last().SetPlayerCords(player.X, player.Y);
                    visuals.Last().Tick = dse.Time;
                    break;
                case EnemySniper es:
                    enemyProjectiles.Add(new ProjectileRay());
                    enemyProjectiles.Last().ProjectileDelete += DeleteObject;
                    enemyProjectiles.Last().Init(es.X, es.Y, 0, 0, Globals.SNIPER_DAMAGE);
                    break;
                case CannonShotgun cs:
                    if (rand.Next(9) < 7)
                        playerProjectiles.Add(new ProjectileSmallScrap());
                    else
                        playerProjectiles.Add(new ProjectileBigScrap());
                    playerProjectiles.Last().ProjectileDelete += DeleteObject;
                    playerProjectiles.Last().Init(player.X, player.Y, cs.VX, cs.VY, cs.Damage);
                    break;
                case CannonBolter cb:
                    playerProjectiles.Add(new ProjectileBullet());
                    playerProjectiles.Last().ProjectileDelete += DeleteObject;
                    playerProjectiles.Last().Init(player.X, player.Y, cb.VX, cb.VY, cb.Damage);
                    break;
            }
        }
        private void DeleteObject(Object obj)
        {
            switch (obj)
            {
                case BarrageEvent be:
                    be.CreateEvent -= CreateObject;
                    be.DeleteEvent -= DeleteObject;
                    events.Remove(be);
                    event_reload = 600;
                    break;
                case DarkSpaceEvent dse:
                    dse.CreateEvent -= CreateObject;
                    dse.DeleteEvent -= DeleteObject;
                    events.Remove(dse);
                    event_reload = 1200;
                    break;
                case Visual_View_Area vva:
                    vva.VisualDelete -= DeleteObject;
                    visuals.Remove(vva);
                    break;
                case ProjectileWave pw:
                    pw.ProjectileDelete -= DeleteObject;
                    enemyProjectiles.Remove(pw);
                    break;
                case ProjectileRay pr:
                    pr.ProjectileDelete -= DeleteObject;
                    enemyProjectiles.Remove(pr);
                    break;
                case Projectile pp:
                    pp.ProjectileDelete -= DeleteObject;
                    playerProjectiles.Remove(pp);
                    break;
                case Enemy en:
                    en.EnemyFire -= CreateObject;
                    en.EnemyDeath -= DeleteObject;
                    en.EnemyColide -= CheckCollision;
                    en.EnemyDeath -= GiveReward;
                    enemies.Remove(en);
                    break;
                case Player pl:
                    player.PlayerCollide -= CheckCollision;
                    player.PlayerDeath -= DeleteObject;
                    player.cannon.CannonFire -= CreateObject;
                    player.PauseGame -= MenuOpen;
                    player.Credits -= Credit;
                    player.GameHint -= HintOpen;
                    for (int i = enemies.Count()-1; i >= 0; i--)
                        player.PlayerMove -= enemies[i].GetTargetCoords;
                    player = new Player();
                    player.Init(400, 400);
                    player.cannon.CannonFire += CreateObject;
                    player.PlayerCollide += CheckCollision;
                    player.PlayerDeath += DeleteObject;
                    player.PauseGame += MenuOpen;
                    player.Credits += Credit;
                    player.GameHint += HintOpen;
                    for (int i = enemies.Count()-1; i >= 0; i--)
                        player.PlayerMove += enemies[i].GetTargetCoords;
                    break;
            }
        }
        public void Credit()
        {
            Credits?.Invoke();

        }
        public void MenuOpen()
        {
            PauseGame?.Invoke();

        }
        public void HintOpen()
        {
            GameHint?.Invoke();
        }
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("save.dat", FileMode.OpenOrCreate))
            {
                //formatter.Serialize(stream, player);
                formatter.Serialize(stream, player.X);
                formatter.Serialize(stream, player.Y);
                formatter.Serialize(stream, player.VX);
                formatter.Serialize(stream, player.VY);
                formatter.Serialize(stream, player.Health);
                formatter.Serialize(stream, player.Shield);
                formatter.Serialize(stream, player.Score);
                formatter.Serialize(stream, player.Coin);
                //formatter.Serialize(stream, tick);
                /*int buf = enemies.Count;
                formatter.Serialize(stream, buf);
                for (int i = 0; i < enemies.Count; i++)
                { 
                    formatter.Serialize(stream, enemies[i]); 
                }*/
            }
        }
        public void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("save.dat", FileMode.Open))
            {
                player.X = (double)formatter.Deserialize(stream);
                player.Y = (double)formatter.Deserialize(stream);
                player.VX = (double)formatter.Deserialize(stream);
                player.VY = (double)formatter.Deserialize(stream);
                player.Health = (int)formatter.Deserialize(stream);
                player.Shield = (int)formatter.Deserialize(stream);
                player.Score = (int)formatter.Deserialize(stream);
                player.Coin = (int)formatter.Deserialize(stream);
                player.Invulnerability += 100;
                /*int buf = (int)formatter.Deserialize(stream);
                    enemies.Clear();
                for (int i = 0; i < buf; i++)
                {
                    Enemy enemy = (Enemy)formatter.Deserialize(stream);
                    enemies.Add(enemy);
                }*/
            }

        }
    }
}
