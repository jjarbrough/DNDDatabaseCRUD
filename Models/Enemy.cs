namespace DNDDatabaseCRUD.Models
{
    public class Enemy
    {
        public int idEnemies { get; set; }
        public int xp { get; set; }
        public int conScore { get; set; }
        public int gold { get; set; }
        public string weaponType { get; set; }
        public string name { get; set; }
        public int health { get; set; }
        public int damageDie { get; set; }
        public bool isAlive { get; set; } = true;

        public Enemy()
        {
            isAlive = true;
        }

    }
}
