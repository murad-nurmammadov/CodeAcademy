using DapperPracticeApp.Models;
using DapperPracticeApp.Repositories.Implements;

namespace DapperPracticeApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        /*
        Product və Category idarəetmə sistemi TƏLƏBLƏR: 
        
        3. Console Application yazın:
        Console-da aşağıdakı seçimlər olsun:
        - 0. Çıxış
        - 1. Product əlavə et 
        - 2. Product update et 
        - 3. Product sil 
        - 4. Bütün Product-ları göstər (GetAll  *yanında categorysidə görünməlidir) 
        - 5. Product-u Id-ə görə tap (GetById) 
        - 6. Category əlavə et 
        - 7. Category update et 
        - 8. Category sil 
        - 9. Bütün Category-ləri göstər (GetAll) 
        - 10. Category-ni Id-ə görə tap (GetById) 
        
        İstifadəçi seçdiyi əməliyyata uyğun yönləndirilsin.

        4. Əlavə Tələblər:
        - Eyni adda Category yaradıla bilməməlidir.
          (Əgər belə bir ad artıq varsa, istifadəçiyə xəbərdarlıq verilsin və yeni əlavə olunmasın.)
        - Əgər bir Category silinmək istənilirsə və bu Category hər hansı bir Product-da istifadə olunursa, Exception throw olunmalıdır.
          (Məsələn: "Bu kateqoriya silinə bilməz, çünki məhsullar tərəfindən istifadə olunur.")

        Qeyd:
        - Kodda mütləq try-catch blokları istifadə edin.
        - İstifadəçinin səhv daxil etdiyi seçimlərdə düzgün xəbərdarlıq verin.
        - Repository metodlarınız sadə və oxunaqlı olmalıdır.
        - Hər əməliyyatdan sonra uğurlu və ya uğursuzluq mesajı göstərilməlidir.
        */


        #region Categories
        GenericRepository<Category> catRepo = new("Categories");
        (await catRepo.GetAllAsync()).ForEach(c => Console.WriteLine(c));
        Console.WriteLine("=====================");

        await catRepo.AddAsync(new Category(0, "cat-1"));
        await catRepo.AddAsync(new Category(0, "cat-2"));
        await catRepo.AddAsync(new Category(0, "cat-1"));
        await catRepo.AddAsync(new Category(0, "cat-2"));
        await catRepo.AddAsync(new Category(0, "cat-2"));


        await catRepo.UpdateAsync(new Category(1, "updated-cat-1"));

        Console.WriteLine(await catRepo.GetByIdAsync(2));
        //Console.WriteLine(catRepo.GetById(200));  // Not found exception

        //catRepo.Delete(new Category(5, "..."));

        Console.WriteLine("=====================");
        (await catRepo.GetAllAsync()).ForEach(c => Console.WriteLine(c));
        #endregion

        Console.WriteLine();
        Console.WriteLine("=====================");
        Console.WriteLine("=====================");
        Console.WriteLine();


        #region Products
        GenericRepository<Product> productRepo = new();
        (await productRepo.GetAllAsync()).ForEach(c => Console.WriteLine(c));
        Console.WriteLine("=====================");

        await productRepo.AddAsync(new Product(0, "prod-1", 20, 1));
        await productRepo.AddAsync(new Product(0, "prod-2", 20, 2));

        await productRepo.UpdateAsync(new Product(1, "updated-prod-1", 20, 2));

        Console.WriteLine(await productRepo.GetByIdAsync(2));
        //Console.WriteLine(catRepo.GetById(200));  // Not found exception

        //productRepo.Delete(new Product(2, "...", 20, 1));

        Console.WriteLine("=====================");
        (await productRepo.GetAllAsync()).ForEach(p => Console.WriteLine(p));
        #endregion
    }
}
