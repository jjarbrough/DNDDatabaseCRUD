using DNDDatabaseCRUD.Interfaces;
using DNDDatabaseCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DNDDatabaseCRUD.Controllers
{
    public class EnemyController : Controller
    {
        private readonly IEnemyRepo repo;

        public EnemyController(IEnemyRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var enemies = repo.GetAllEnemies();
            return View(enemies);
        }

        public IActionResult ViewEnemy(int id)
        {
            var enemy = repo.GetEnemy(id);
            return View(enemy);
        }

        public IActionResult UpdateEnemy(int id)
        {
            Enemy enemy = repo.GetEnemy(id);
            if (enemy == null)
            {
                return View("ProductNotFound");
            }
            return View(enemy);
        }

        public IActionResult UpdateEnemyToDatabase(Enemy enemy)
        {
            repo.UpdateEnemy(enemy);

            return RedirectToAction("ViewEnemy", new { id = enemy.idEnemies });
        }

        public IActionResult InsertEnemy()
        {
            Enemy enemy = new Enemy();
            return View(enemy);
        }

        public IActionResult InsertEnemyToDatabase(Enemy enemy)
        {
            repo.InsertEnemy(enemy);
            return RedirectToAction("InsertEnemy");
        }

        public IActionResult DeleteEnemy(Enemy enemy)
        {
            repo.DeleteEnemy(enemy);
            return RedirectToAction("Index");
        }
    }
}
