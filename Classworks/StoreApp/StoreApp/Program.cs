using StoreApp.Models;

namespace StoreApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            1. Bir market var. IModel interface ini implement edir(Id propertysi 
                var içində)
            2. Marketin Id-si və adı var.
            3. Məhsul modeliniz olur IModel interface ini implement edir.
            4. Marketin içində məhsullar var.
            5. Marketə məhsul əlavə etmək olur. Əgər məhsul marketdə mövcudursa 
                ProductAlreadyExist exceptionu throw olunsun.
            6. Marketdən məhsul silmək olur. Silinən məhsul tapılmadığı halda 
                ProductNotFound exceptionu throw olunsun.
            7. Məhsulların hər birinin Id nömrəsi, adı, əldə olan sayı və qiyməti 
                var.
            8. Marketdəki bütün məhsullara baxmaq mümkün olsun. [Məhsulun ID nömrəsi, 
                adı, marketdəki sayı, qiyməti]
            9. Hər bir obyektin Id nömrəsi avtomatik olaraq özündən əvvəlki obyektdən 
                1 vahid çox olmalıdır. [1-dən başlayaraq]

            10. İstənilən məhsul haqqında ətraflı məlumatı ekrana çıxarmaq olsun.
            */

            Store store = new Store("Murad Store", []);
            Console.WriteLine(store);
            Console.WriteLine(store.Products);

            Product product1 = new Product("Product 1", 2, 3.55f);
            Product product2 = new Product("Product 2", 7, 15.99f);

            store.AddProduct(product1);
            store.AddProduct(product2);


            //store.ShowProductInfoByID(product1.Id);
            Console.WriteLine(product1.ID);
            Console.WriteLine(product2.ID);

        }
    }
}
