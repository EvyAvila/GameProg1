using Microsoft.AspNetCore.Mvc;
using WebAppMVCWeapon.Controllers;
using WebAppMVCWeapon.Models;

namespace TestProjectMVCWeapon
{
    [TestClass]
    public class WeaponControllerTest
    {
        [TestMethod]
        public void WeaponControllerIndexTest()
        {
            //Arrange
            Weapon weapon;
            weapon = new AutoRifle();
            WeaponRepo repo = new WeaponRepo();
            repo.Weapons.Add(weapon);

            var weaponController = new WeaponController();

            //Act
            var result = (ViewResult)weaponController.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual(repo.Weapons.GetType(), result.Model.GetType());
        }

        [TestMethod] //Come back
        public void WeaponControllerCreateNewWeaponTest()
        {
            //Arrange
            Weapon weapon;
            weapon = new Weapon() { Name = "Herod-C" };
            WeaponRepo repo = new WeaponRepo();
            var weaponController = new WeaponController();
            int weaponCountPrev, weaponCountAfterAdd;

            //Act
            weaponCountPrev = WeaponController.repo.Weapons.Count();
            var result = weaponController.Create(weapon);
            repo.AddWeapon(weapon);
            weaponCountAfterAdd = WeaponController.repo.Weapons.Count();

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual(weaponCountPrev + 1, weaponCountAfterAdd);
            Assert.AreEqual(weaponCountAfterAdd, repo.Weapons.Count());
        }

        [TestMethod]
        public void WeaponControllerEditWeaponTest()
        {
            //Arrange
            Weapon w;
            w = new Weapon() { Name = "Herod-C", AmmoAmount = 40, RoundsPerShot = 3, WeaponLevel = 1350, MaxAmmoAmount = 40 };
            WeaponRepo repo = new WeaponRepo();
            var weaponController = new WeaponController();

            int PreviousWeaponLevel, NewWeaponLevel;
            int GetID;

            //Act
            GetID = repo.Weapons.Count;

            WeaponController.repo.AddWeapon(w);
            PreviousWeaponLevel = WeaponController.repo.Weapons[GetID].WeaponLevel;

            weaponController.Create(w);
            var result = weaponController.Edit(GetID);

            WeaponController.repo.Weapons[GetID].WeaponLevel = 1575;
           
            NewWeaponLevel = WeaponController.repo.Weapons[GetID].WeaponLevel;


            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual(1350, PreviousWeaponLevel);
            Assert.AreEqual(1575, NewWeaponLevel);
        }

        [TestMethod]
        public void WeaponControllerDetailWeaponTest()
        {
            //Arrange
            Weapon w;
            w = new Weapon() { Name = "Herod-C", AmmoAmount = 40, RoundsPerShot = 3, WeaponLevel = 1350, MaxAmmoAmount = 40 };
            WeaponRepo repo = new WeaponRepo();
            var weaponController = new WeaponController();

            string name, weaponName;
            int ammoAmount, maxAmmoAmount, roundShot, weaponLevel;

            int GetID;
            //Act

            GetID = repo.Weapons.Count();
            repo.AddWeapon(w);

            var result = weaponController.Details(GetID);
            name = repo.Weapons[GetID].Name;
            weaponName = repo.Weapons[GetID].WeaponTypeName;
            ammoAmount = repo.Weapons[GetID].AmmoAmount;
            maxAmmoAmount = repo.Weapons[GetID].MaxAmmoAmount;
            roundShot = repo.Weapons[GetID].RoundsPerShot;
            weaponLevel = repo.Weapons[GetID].WeaponLevel;


            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Herod-C", name);
            Assert.AreEqual("Auto Rifle", weaponName);
            Assert.AreEqual(40, ammoAmount);
            Assert.AreEqual(40, maxAmmoAmount);
            Assert.AreEqual(3, roundShot);
            Assert.AreEqual(1350, weaponLevel);

        }

        //Testing shoot
        [TestMethod]
        public void WeaponControllerShootTest()
        {
            //Arrange
            Weapon w;
            w = new Weapon() { Name = "Herod-C", AmmoAmount = 40, RoundsPerShot = 3, WeaponLevel = 1350, MaxAmmoAmount = 40 };
            WeaponRepo repo = new WeaponRepo();
            var weaponController = new WeaponController();
            int GetID;

            int AmmoPrev, AmmoAfter, AmmoReachZero;

            //Act
            GetID = repo.Weapons.Count();
            repo.AddWeapon(w);


            AmmoPrev = repo.Weapons[GetID].AmmoAmount;

            var result = weaponController.Shoot(0);

            repo.ShootWeapon(GetID);

            AmmoAfter = repo.Weapons[GetID].AmmoAmount;

            for (int i = 0; i < AmmoPrev; i++)
            {
                repo.ShootWeapon(GetID);
            }

            AmmoReachZero = repo.Weapons[GetID].AmmoAmount;

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual(40, AmmoPrev);
            Assert.AreEqual(37, AmmoAfter);
            Assert.AreEqual(0, AmmoReachZero);

        }

        //Testing reload
        [TestMethod]
        public void WeaponControllerReloadTest()
        {
            //Arrange
            Weapon w;
            w = new Weapon() { Name = "Herod-C", AmmoAmount = 40, RoundsPerShot = 3, WeaponLevel = 1350, MaxAmmoAmount = 40 };
            WeaponRepo repo = new WeaponRepo();
            var weaponController = new WeaponController();
            int GetID;

            int AmmoPrev, AmmoZero, AmmoFullAgain;

            //Act
            GetID = repo.Weapons.Count();
            repo.AddWeapon(w);

            AmmoPrev = repo.Weapons[GetID].AmmoAmount;

            for (int i = 0; i < AmmoPrev; i++)
            {
                repo.ShootWeapon(GetID);
            }

            AmmoZero = repo.Weapons[GetID].AmmoAmount;

            var result = weaponController.Reload(0);
            repo.ReloadWeapon(GetID);
            AmmoFullAgain = repo.Weapons[GetID].AmmoAmount;

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual(40, AmmoPrev);
            Assert.AreEqual(0, AmmoZero);
            Assert.AreEqual(40, AmmoFullAgain);
        }
    }
}