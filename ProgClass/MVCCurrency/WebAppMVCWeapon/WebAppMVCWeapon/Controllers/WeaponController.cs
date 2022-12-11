using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCWeapon.Models;

namespace WebAppMVCWeapon.Controllers
{
    public class WeaponController : Controller
    {
        public static WeaponRepo repo;
        //public IWeaponRepo repo;

        public WeaponController()
        {
            
            if(repo == null)
            {
                repo = new WeaponRepo();
            }
            /*
            if(repo == null)
            {
                repo = _repo;

            }*/
           
        }

        // GET: WeaponController
        public ActionResult Index()
        {
            return View(repo.Weapons);
        }

        // GET: WeaponController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetWeaponByID(id));
        }

        // GET: WeaponController/Create
        public ActionResult Create()
        {
            return View(new Weapon());
        }

        // POST: WeaponController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Weapon w)
        {
            repo.AddWeapon(w);
            return RedirectToAction(nameof(Index));
           
        }

        // GET: WeaponController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetWeaponByID(id));
        }

        // POST: WeaponController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Weapon updateWeapon = repo.GetWeaponByID(int.Parse(collection["ID"]));
                
                updateWeapon.Name= collection["Name"];
                updateWeapon.WeaponTypeName = collection["WeaponTypeName"];
                updateWeapon.AmmoAmount = int.Parse(collection["AmmoAmount"]);
                updateWeapon.RoundsPerShot = int.Parse(collection["RoundsPerShot"]);
                updateWeapon.WeaponLevel = int.Parse(collection["WeaponLevel"]);

                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
           
        }

        public IActionResult Shoot(int id)
        {
            repo.ShootWeapon(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Reload(int id)
        {
            repo.ReloadWeapon(id);
            return RedirectToAction(nameof(Index));
        }
        /* 
        // GET: WeaponController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeaponController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
