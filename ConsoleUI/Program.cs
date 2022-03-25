using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest(); //method haline getirmek istediğim yerleri seçip sağ tık quick actions and.. deyip yeni method haline getirdim. çirkin görünmesin diye yaptım.
            //CategoryTest();


        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal())); //beni newleyebilmen için hangi productdal yöntemi ile çalıştığımı
                                                                                    //söylemen lazım.
            var result = productManager.GetProductDetails();

            if (result.Succsess==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
