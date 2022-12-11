namespace WebAppMVCWeapon.Models
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public string WeaponTypeName { get; set; }
        public int AmmoAmount { get; set; }
        public int MaxAmmoAmount { get; set; }
        public int RoundsPerShot { get; set; }
        public int WeaponLevel { get; set; }

        public int ID { get; set; }

        protected static int WeaponCount;

        

        public Weapon()
        {
            this.Name = "Ammit AR2";
            this.WeaponTypeName = "Auto Rifle";
            this.AmmoAmount = 32;
            this.RoundsPerShot = 4;
            this.WeaponLevel = 1350;
            this.ID = WeaponCount++;
            this.MaxAmmoAmount = AmmoAmount;
        }
    }

    public class AutoRifle : Weapon
    {
        public AutoRifle()
        {
            this.Name = "Krait";
            this.WeaponTypeName = "Auto Rifle";
            this.AmmoAmount = 53;
            this.RoundsPerShot = 5;
            this.WeaponLevel = 1580;
            this.MaxAmmoAmount = AmmoAmount;
        }
    }

}
