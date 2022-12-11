namespace WebAppMVCWeapon.Models
{
   
    public class WeaponRepo 
    {
        public List<Weapon> Weapons { get; set; }

        public WeaponRepo()
        {
            this.Weapons = new List<Weapon>()
            {
                new AutoRifle(),
                new AutoRifle() {Name="Firefright",  AmmoAmount=40, RoundsPerShot=3, WeaponLevel=1570, MaxAmmoAmount = 40}
            };
        }

        public Weapon GetWeaponByID(int id)
        {
            return (Weapon)Weapons.Where(w => w.ID == id).FirstOrDefault();
        }

        public void ShootWeapon(int id)
        {
            Weapons.Where(w => w.ID == id).FirstOrDefault();
            CheckAmmo(id);
        }

        private void CheckAmmo(int id)
        {
            if (Weapons[id].AmmoAmount > Weapons[id].RoundsPerShot)
            {
                Weapons[id].AmmoAmount -= Weapons[id].RoundsPerShot;
            }
            else
            {
                Weapons[id].AmmoAmount = 0;
            }
        }

        public void ReloadWeapon(int id)
        {
            Weapons.Where(w => w.ID == id).FirstOrDefault();
            Weapons[id].AmmoAmount = Weapons[id].MaxAmmoAmount;
        }

        public void AddWeapon(Weapon weapon) 
        {
            CheckForNegativeNumber(weapon);
            
            this.Weapons.Add(weapon);
        }

        private void CheckForNegativeNumber(Weapon weapon)
        {
            //If user inserts a low value, it'll create a low default value
            if (weapon.MaxAmmoAmount <= 0)
            {
                weapon.MaxAmmoAmount = 20;
            }
        }
    }
}
