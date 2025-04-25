using PizzaMizzaApp.Models;
using PizzaMizzaApp.Repositories.Implements;

namespace PizzaMizzaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            PizzaMizza-nın menyu sistemini yığın.
            1. Pizzalara bax
            2. Pizza əlavə et
            3. Pizza sil
            4. Pizzanı yenilə

            Pizza əlavə edilən zaman
            Adı, Qiyməti və neçə ingredient olduğunu, daha sonra ingredientlərin id-sini daxil edin.
            Pizzalara baxan zaman
            Pizzaların idsini yazıb ingredientlərinə baxmaq olsun
            */

            #region Pizza Repository
            //// Note: Run sql query in ms sql first
            //GenericRepository<Pizza> repo = new();


            //// GET ALL
            //List<Pizza> pizzas = repo.GetAll();
            //pizzas.ForEach(p => Console.WriteLine(p));
            //Console.WriteLine("========================");

            //// ADD
            //repo.Add(new Pizza(0, "new-pizza-1", 9.99f));
            //repo.Add(new Pizza(0, "new-pizza-2", 9.99f));

            //// UPDATE
            //repo.Update(new Pizza(1, "update-pizza-1", 9.99f));

            //// DELETE
            //repo.Delete(2);
            ////repo.Delete(100);  // Not Found

            //// GET BY ID
            //Console.WriteLine(repo.GetById(1));
            //Console.WriteLine(repo.GetById(4));
            ////Console.WriteLine(repo.GetById(2)); // Not found

            //// GET ALL
            //Console.WriteLine("========================");
            //pizzas = repo.GetAll();
            //pizzas.ForEach(p => Console.WriteLine(p));
            #endregion

            #region Ingredient Repository
            //// Note: Run sql query in ms sql first
            //GenericRepository<Ingredient> repo = new();

            //// GET ALL
            //List<Ingredient> ingredients = repo.GetAll();
            //ingredients.ForEach(p => Console.WriteLine(p));
            //Console.WriteLine("========================");

            //// ADD
            //repo.Add(new Ingredient(0, "new-ingredient-1"));
            //repo.Add(new Ingredient(0, "new-ingredient-2"));

            //// UPDATE
            //repo.Update(new Ingredient(1, "update-ingredient-1"));

            //// DELETE
            //repo.Delete(2);
            ////repo.Delete(100);  // Not Found

            //// GET BY ID
            //Console.WriteLine(repo.GetById(1));
            //Console.WriteLine(repo.GetById(4));
            ////Console.WriteLine(repo.GetById(2)); // Not found

            //// GET ALL
            //Console.WriteLine("========================");
            //ingredients = repo.GetAll();
            //ingredients.ForEach(p => Console.WriteLine(p));
            #endregion
        }
    }
}
