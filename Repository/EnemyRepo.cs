using Dapper;
using DNDDatabaseCRUD.Interfaces;
using DNDDatabaseCRUD.Models;
using System.Data;

namespace DNDDatabaseCRUD.Repository
{
    public class EnemyRepo : IEnemyRepo
    {
        private readonly IDbConnection _conn;
        public EnemyRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Enemy> GetAllEnemies()
        {
            return _conn.Query<Enemy>("SELECT * FROM Enemy;");
        }

        public Enemy GetEnemy(int id)
        {
            return _conn.QuerySingle<Enemy>("SELECT * FROM Enemy WHERE idEnemies = @id", new { id });
        }

        public void InsertEnemy(Enemy enemy)
        {
            _conn.Execute("INSERT INTO enemy (xp, conScore, gold, weaponType, name, health, damageDie, isAlive) VALUES (@xp, @conScore, @gold, @weaponType, @name, @health, @damageDie, @isAlive);",
                new { enemy.name, enemy.damageDie, enemy.health, enemy.weaponType, enemy.gold, enemy.conScore, enemy.xp, enemy.isAlive, id = enemy.idEnemies });
        }

        public void UpdateEnemy(Enemy enemy)
        {
            _conn.Execute("UPDATE enemy SET name = @name, damageDie = @damageDie, health = @health, weaponType = @weaponType, gold = @gold, conScore = @conScore, xp = @xp WHERE idEnemies = @id",
             new { enemy.name, enemy.damageDie, enemy.health, enemy.weaponType, enemy.gold, enemy.conScore, enemy.xp, id = enemy.idEnemies });
        }

        public void DeleteEnemy(Enemy enemy)
        {
            _conn.Execute("DELETE FROM enemy WHERE idEnemies = @id;", new { id = enemy.idEnemies });
        }
    }
}
