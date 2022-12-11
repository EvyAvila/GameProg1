namespace WebAppMVCWeapon.Models
{
    public interface IWeapon
    {
        public string Name { get; set; }
        public string WeaponTypeName { get; set; }
        public int AmmoAmount { get; set; }
        int MaxAmmoAmount { get; set; }
        public int RoundsPerShot { get; set; }

        public int WeaponLevel { get; set; }
        int ID { get; set; }
        //public int ID { get; set; }
    }

}
