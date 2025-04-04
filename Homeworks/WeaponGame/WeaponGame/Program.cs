﻿namespace WeaponGame
{
    class Porgram
    {
        static void Main()
        {
            /*
            Class: Weapon
            Properties: Darağın güllə tutumu, Daraqdakı güllə sayı,atış modu (təkli və ya avtomatik)
            Methods:
            * Shoot() -> metodu hər çağırıldıqda fire moduna gore ya 1 güllə atır yada avtomatik gulleni bosaldir.(Ekranda bunu bildirir)
            * GetRemainBulletCount() -> darağın tam dolması üçün lazım olan güllə sayını qaytarır.
            * Reload() -> darağı yenidən doldurur.
            * ChangeFireMode() -> Atış modunu dəyişir.
            
            Bütün məlumatları doldurmadan obyekt yaratmaq olmasın.

            Shortcuts (Menu):
            0 -> İnformasiya almaq üçün
            1 -> Shoot metodu üçün
            2 -> GetRemainBulletCount metodu üçün
            3 -> Reload metodu üçün
            4 -> ChangeFireMode metodu üçün
            5 -> Proqramdan dayandırmaq üçün
            */

            Weapon weapon = new Weapon(60, 27, true);

            string shortcut = "0";

            // Menu
            Console.WriteLine("============================");
            Console.WriteLine("Enter shortcut:");
            Console.WriteLine("0 -> get info");
            Console.WriteLine("1 -> shoot");
            Console.WriteLine("2 -> get bullets until full");
            Console.WriteLine("3 -> reload");
            Console.WriteLine("4 -> change fire mode");
            Console.WriteLine("5 -> exit application");
            Console.WriteLine("============================");

            while (shortcut != "5")
            {
                shortcut = Console.ReadLine();

                switch (shortcut)
                {
                    case "0": { weapon.GetInfo(); break; }
                    case "1": { weapon.Shoot(); break; }
                    case "2": { weapon.BulletsUntilFull(); break; }
                    case "3": { weapon.Reload(); break; }
                    case "4": { weapon.ChangeFireMode(); break; }
                    case "5": { return; }  // return in Main() method terminates the app

                    // Invalid option
                    default: { Console.WriteLine("Invalid option! Enter again!"); break; }
                }
            }
        }
    }
}
