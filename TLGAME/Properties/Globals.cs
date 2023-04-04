namespace TLGAME
{
    public static class Globals
    {
        #region GLOBALS
        public static int UPDATE_TIME = 9; //Скорость анимации
        public static int TIMER_INTERVAL = 1;  //Время между кадрами
        public static int SCORE_REWARD_TIME = 80; //Время между вознагрождениями
        #endregion

        #region INTERFACE
        public static int INTERFACE_UPDATE_TIME = 40;
        public static int TEXT_SMALL = 1;
        public static int TEXT_MEDIUM = 2;
        public static int TEXT_LARGE = 3;
        #endregion

        #region EVENTS
        public static int DARK_SPACE_TIME = 2000;
        public static int BARRAGE_TIME = 600;
        public static int BARRAGE_RELOAD = 40;
        public static int BARRAGE_DAMAGE = 6;
        public static double BARRAGE_ACCURACY = 0.4;
        #endregion

        #region PLAYER
        public static double PLAYER_SPEED_VX = 3.5;
        public static double PLAYER_SPEED_VY = 3.5;
        public static int PLAYER_MAX_HEALTH = 30; //Максимальное число жизней игрока
        public static int PLAYER_MAX_SHIELD = 10; //Максимальное число щита игрока
        public static int PLAYER_INVULNERABILITY_TIME = 80; //Время неуязвимости
        public static int PLAYER_SHIELD_RECOVER_TIME = 600;
        public static int PLAYER_SHIELD_RECOVER_SPEED = 100;
        public static int PLAYER_SHIELD_RECOVER_AMOUNT = 1;
        #region CANNON BOLTER
        public static double CANNON_BOLTER_ACCURACY = 0.97;
        public static double CANNON_BOLTER_VX = 0; //Поправка скорости пушки по x
        public static double CANNON_BOLTER_VY = -1; //Поправка скорости пушки по y
        public static int CANNON_BOLTER_DAMAGE = 6; //Урон пушки
        public static int CANNON_BOLTER_RELOAD = 25; //Перезарядка пушки
        public static object CANNON_BOLTER_TYPE = new CannonBolter();
        #endregion
        #region CANNON SHOTGUN
        public static double CANNON_SHOTGUN_ACCURACY = 0.50;
        public static double CANNON_SHOTGUN_VX = 0; //Поправка скорости пушки по x
        public static double CANNON_SHOTGUN_VY = +1; //Поправка скорости пушки по y
        public static int CANNON_SHOTGUN_DAMAGE = 2; //Урон пушки
        public static int CANNON_SHOTGUN_DAMAGE_MULTIPLIER = 3; //Множитель большого снаряда
        public static int CANNON_SHOTGUN_RELOAD = 70; //Перезарядка пушки
        public static object CANNON_SHOTGUN_TYPE = new CannonShotgun();
        #endregion
        #region BULLET
        public static double BULLET_SPEED_VY = 7.50; //Начальная скорость пули
        #endregion
        #endregion

        #region SNIPER
        public static int SNIPER_MAX_HEALTH = 18; //Максимальное хп снайпера
        public static int SNIPER_MOVING_TIME = 10; //Время "блуждания" снайпера
        public static int SNIPER_FIRE_TIME = 10; //Время стрельбы снайпера
        public static int SNIPER_DAMAGE = 5; //Урон снайпера
        public static double SNIPER_SPEED = 0.9; //скорость снайпера
        public static double SNIPER_CONVERGENCE = 200; //расстояние сближения
        #endregion
    }
}
