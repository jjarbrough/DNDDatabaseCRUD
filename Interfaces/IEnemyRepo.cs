using DNDDatabaseCRUD.Models;

namespace DNDDatabaseCRUD.Interfaces
{
    public interface IEnemyRepo
    {
        public IEnumerable<Enemy> GetAllEnemies();
        public Enemy GetEnemy(int id);
        public void UpdateEnemy(Enemy enemy);
        public void InsertEnemy(Enemy enemy);
        public void DeleteEnemy(Enemy enemy);
    }
}
