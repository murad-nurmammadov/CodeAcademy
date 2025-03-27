namespace WeaponGame
{
    class Weapon
    {
        public byte BulletCapacity;
        public byte BulletCount;
        public bool IsSingleShot;  // Shooting modes: single, continuous

        public Weapon(byte bulletCapacity, byte bulletCount, bool isSingleShot)
        {
            if (bulletCount > bulletCapacity)
            {
                Console.WriteLine("Bullet count cannot exceed bullet capacity!");
                return;
            }

            BulletCapacity = bulletCapacity;
            BulletCount = bulletCount;
            IsSingleShot = isSingleShot;
        }

        public void GetInfo()
        {
            string shootingMode = (IsSingleShot) ? "single shot" : "continuous shot";
            Console.WriteLine($"Weapon: {BulletCount}/{BulletCapacity} bullets, {shootingMode}");
        }

        public void Shoot()
        {
            if (BulletCount == 0)
            {
                Console.WriteLine("No bullets!");
                return;
            }

            if (IsSingleShot)
            {
                Console.WriteLine("Shooted! (-1 bullet)");
                BulletCount--;
            }
            else
            {
                Console.WriteLine($"Shooted! (-{BulletCount} bullets)");
                BulletCount = 0;
            }
        }

        public void BulletsUntilFull()
        {
            byte bulletsUntilFull = Convert.ToByte(BulletCapacity - BulletCount);
            Console.WriteLine($"{bulletsUntilFull} bullets for reload.");
        }

        public void Reload()
        {
            BulletCount = BulletCapacity;
            Console.WriteLine("Reloaded!");
        }

        public void ChangeFireMode()
        {
            if (IsSingleShot) { Console.WriteLine("Changed to continuous-shot mode!"); }
            else { Console.WriteLine("Changed to single-shot mode!"); }

            IsSingleShot = !IsSingleShot;

        }
    }
}
