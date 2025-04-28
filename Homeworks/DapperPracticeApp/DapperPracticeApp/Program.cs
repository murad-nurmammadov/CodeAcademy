using DapperPracticeApp.Exceptions;
using DapperPracticeApp.Models;
using DapperPracticeApp.Repositories.Implements;

namespace DapperPracticeApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        /*
        Product və Category idarəetmə sistemi TƏLƏBLƏR: 
        
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

        string shortcut = "";

        while (shortcut != "0")
        {
            Console.WriteLine("""                
                # PRODUCTS #
                1 -> Add product
                2 -> Update product
                3 -> Delete product
                4 -> Get product by id
                5 -> Get all products

                # CATEGORIES #
                6 -> Add category
                7 -> Update category
                8 -> Delete category
                9 -> Get category by id
                10 -> Get all categories

                # EXIT #
                0 -> Exit

                ==========================
                Enter shortcut:
                """);

            GenericRepository<Category> catRepo = new("Categories");
            GenericRepository<Product> prodRepo = new();

            shortcut = Console.ReadLine();

            switch (shortcut)
            {
                case "0": return;

                // ADD, UPDATE, DELETE, GET BY ID, GET ALL
                case "1":
                    Product product = _getProductInfo(false);
                    int nRows = await prodRepo.AddAsync(product);
                    Console.WriteLine("Product was added successfully!");
                    break;

                case "2":
                    try
                    {
                        product = _getProductInfo(true);
                        nRows = await prodRepo.UpdateAsync(product);
                        Console.WriteLine("Product was added successfully!");
                    }
                    catch (ItemNotFoundException e) { Console.WriteLine(e.Message); }
                    break;

                case "3":
                    try
                    {
                        int id = _getItemId();
                        nRows = await prodRepo.DeleteAsync(id);
                        Console.WriteLine("Product was added successfully!");
                    }
                    catch (ItemNotFoundException e) { Console.WriteLine(e.Message); }
                    break;

                case "4": break;

                case "5": break;

                // ADD, UPDATE, DELETE, GET BY ID, GET ALL
                case "6": break;
                case "7": break;
                case "8": break;
                case "9": break;
                case "10": break;
            }
        }

        #region Categories
        //Console.WriteLine("### CATEGORIES ###");
        //GenericRepository<Category> catRepo = new("Categories");
        //(await catRepo.GetAllAsync()).ForEach(c => Console.WriteLine(c));
        //Console.WriteLine("=====================");
        //await catRepo.AddAsync(new Category(0, "cat-1"));
        //await catRepo.AddAsync(new Category(0, "cat-2"));
        //await catRepo.AddAsync(new Category(0, "cat-3"));
        //await catRepo.AddAsync(new Category(0, "cat-4"));
        //await catRepo.AddAsync(new Category(0, "cat-5"));
        //await catRepo.UpdateAsync(new Category(1, "updated-cat-1"));
        //Console.WriteLine(await catRepo.GetByIdAsync(2));
        ////Console.WriteLine(catRepo.GetById(200));  // Not found exception
        ////catRepo.Delete(new Category(5, "..."));
        //Console.WriteLine("=====================");
        //(await catRepo.GetAllAsync()).ForEach(c => Console.WriteLine(c));
        #endregion

        #region Products
        //Console.WriteLine("### PRODUCTS ###");
        //GenericRepository<Product> productRepo = new();
        //(await productRepo.GetAllAsync()).ForEach(c => Console.WriteLine(c));
        //Console.WriteLine("=====================");
        //await productRepo.AddAsync(new Product(0, "prod-1", 20, 1));
        //await productRepo.AddAsync(new Product(0, "prod-2", 20, 2));
        //await productRepo.UpdateAsync(new Product(1, "updated-prod-1", 20, 2));
        //Console.WriteLine(await productRepo.GetByIdAsync(2));
        ////Console.WriteLine(catRepo.GetById(200));  // Not found exception
        ////productRepo.Delete(new Product(2, "...", 20, 1));
        //Console.WriteLine("=====================");
        //(await productRepo.GetAllAsync()).ForEach(p => Console.WriteLine(p));
        #endregion
    }

    static Product _getProductInfo(bool getId)
    {
        int id = 0;
        if (getId)
        {
            Console.WriteLine("Enter product id:");
            id = Convert.ToInt32(Console.ReadLine());
        }

    name_checkpont:
        Console.WriteLine("Enter product name:");
        string name = Console.ReadLine();

        if (name is null)
        {
            Console.WriteLine("Name cannot be null! Try again...");
            goto name_checkpont;
        }

        Console.WriteLine("Enter product price:");
        decimal price = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter product category id:");
        int categoryId = Convert.ToInt32(Console.ReadLine());

        return new Product(id, name, price, categoryId);
    }

    static int _getItemId()
    {
    id_checkpoint:
        Console.WriteLine("Enter id:");
        if (int.TryParse(Console.ReadLine(), out int id))
            return id;
        else goto id_checkpoint;
    }
}
