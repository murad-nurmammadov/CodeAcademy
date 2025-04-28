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

        GenericRepository<Product> prodRepo = new();
        GenericRepository<Category> catRepo = new("Categories");

        string shortcut = "";

        while (shortcut != "0")
        {
            Console.Clear();  // Clear console for fresh menu each time

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

            shortcut = Console.ReadLine();

            switch (shortcut)
            {
                case "0": return;

                // Products
                case "1": AddProduct(prodRepo); break;
                case "2": UpdateProduct(prodRepo); break;
                case "3": DeleteProduct(prodRepo); break;
                case "4": GetProductById(prodRepo); break;
                case "5": GetAllProducts(prodRepo); break;

                // Categories
                case "6": AddCategory(catRepo); break;
                case "7": UpdateCategory(catRepo); break;
                case "8": DeleteCategory(catRepo); break;
                case "9": GetCategoryById(catRepo); break;
                case "10": GetAllCategories(catRepo); break;

                default: Console.WriteLine("Invalid shortcut!"); break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    #region switch - product methods
    private static async Task AddProduct(GenericRepository<Product> repo)
    {
        Product product = GetProductInfo(false);
        int nRows = await repo.AddAsync(product);
        Console.WriteLine("Product was successfully added!");
    }
    private static async Task UpdateProduct(GenericRepository<Product> repo)
    {
        try
        {
            Product product = GetProductInfo(true);
            int nRows = await repo.UpdateAsync(product);
            Console.WriteLine("Product was successfully updated!");
        }
        catch (ItemNotFoundException e) { Console.WriteLine(e.Message); }
    }
    private static async Task DeleteProduct(GenericRepository<Product> repo)
    {
        try
        {
            Product product = GetProductInfo(true);
            int nRows = await repo.DeleteAsync(product);
            Console.WriteLine("Product was successfully deleted!");
        }
        catch (ItemNotFoundException e) { Console.WriteLine(e.Message); }
    }
    private static async Task GetProductById(GenericRepository<Product> repo)
    {
        try
        {
            int id = GetItemId();
            Product product = await repo.GetByIdAsync(id);
            Console.WriteLine("Here is the product:");
            Console.WriteLine(product);
        }
        catch (ItemNotFoundException e) { Console.WriteLine(e.Message); }
    }
    private static async Task GetAllProducts(GenericRepository<Product> repo)
    {
        try
        {
            List<Product> products = await repo.GetAllAsync();
            Console.WriteLine("Here are the products:");
            products.ForEach(p => Console.WriteLine(p));
        }
        catch (ItemNotFoundException e) { Console.WriteLine(e.Message); }
    }
    #endregion

    #region switch - category methods
    private static async Task AddCategory(GenericRepository<Category> repo)
    {
        Category category = GetCategoryInfo(false);
        int nRows = await repo.AddAsync(category);
        Console.WriteLine("Category was successfully added !");
    }
    private static async Task UpdateCategory(GenericRepository<Category> repo)
    {
        try
        {
            Category category = GetCategoryInfo(true);
            int nRows = await repo.UpdateAsync(category);
            Console.WriteLine("Category was successfully updated!");
        }
        catch (ItemNotFoundException e) { Console.WriteLine(e.Message); }
    }
    private static async Task DeleteCategory(GenericRepository<Category> repo)
    {
        try
        {
            Category category = GetCategoryInfo(true);
            int nRows = await repo.DeleteAsync(category);
            Console.WriteLine("Category was successfully deleted!");
        }
        catch (ItemNotFoundException e) { Console.WriteLine(e.Message); }
    }
    private static async Task GetCategoryById(GenericRepository<Category> repo)
    {
        try
        {
            int id = GetItemId();
            Category category = await repo.GetByIdAsync(id);
            Console.WriteLine("Here is the category:");
            Console.WriteLine(category);
        }
        catch (ItemNotFoundException e) { Console.WriteLine(e.Message); }

    }
    private static async Task GetAllCategories(GenericRepository<Category> repo)
    {
        try
        {
            List<Category> categories = await repo.GetAllAsync();
            Console.WriteLine("Here are the categories:");
            categories.ForEach(p => Console.WriteLine(p));
        }
        catch (ItemNotFoundException e) { Console.WriteLine(e.Message); }

    }
    #endregion

    #region utility methods
    static Product GetProductInfo(bool getId)
    {
        int id = 0;
        if (getId)
        {
            while (true)
            {
                Console.WriteLine("Enter product id:");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                Console.WriteLine("Id needs to be an integer! Try again...");
            }
        }

        string name;
        while (true)
        {
            Console.WriteLine("Enter product name:");
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                break;
            Console.WriteLine("Name cannot be empty! Try again...");
        }

        decimal price;
        while (true)
        {
            Console.WriteLine("Enter product price:");
            if (decimal.TryParse(Console.ReadLine(), out price))
                break;
            Console.WriteLine("Price needs to be a decimal number! Try again...");
        }

        int categoryId;
        while (true)
        {
            Console.WriteLine("Enter product's category id:");
            if (int.TryParse(Console.ReadLine(), out categoryId))
                break;
            Console.WriteLine("Category Id needs to be an integer! Try again...");
        }

        return new Product(id, name, price, categoryId);
    }
    static Category GetCategoryInfo(bool getId)
    {
        int id = 0;
        if (getId)
        {
            while (true)
            {
                Console.WriteLine("Enter category id:");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                Console.WriteLine("Id needs to be an integer! Try again...");
            }
        }

        string name;
        while (true)
        {
            Console.WriteLine("Enter category name:");
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                break;
            Console.WriteLine("Name cannot be empty! Try again...");
        }

        return new Category(id, name);
    }
    static int GetItemId()
    {
        int id;
        while (true)
        {
            Console.WriteLine("Enter id:");
            if (int.TryParse(Console.ReadLine(), out id))
                return id;
            Console.WriteLine("Id needs to be integer! Try again...");
        }
    }
    #endregion
}
