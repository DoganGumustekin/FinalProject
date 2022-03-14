using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //bellek üzerinde ürünle ilgili veri erişim kodlarının yazılacağı yer.
    //inmemoryproductdal = productdal ın inmemory veri erişim tekniği.
    public class InMemoryProductDal : IProductDal 
    {
        List<Product> _products; //bir ürün listesi oluşturalım C# ta global değişken isimleri 
                                 // _ ile başlar.
                                 //buranın görevi proje başlatıldığında bir ürün listesi oluşturulsun
        public InMemoryProductDal() //bu altta tanımlananlar sanki bize bir veritabanından geliyormuş gibi 
                                    //düşünebiliriz constructor olduğu için proje çalıştığında otomatik çalışacak.
        {
            _products = new List<Product> {  //içerisinde ürünleri barındıran bir liste
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product); //business ten gelen veriyi veri tabanına (şuanlık veritabanım _product tır. simüle ettik)ekle.
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query(dile gömülü sorgulama)
            //=> lambda denir.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //buna linq deniyor c# ı diğer dillerden güçlü kılar.  
            //singleordefault bir eleman bulmmaya yarar.
            //_products ı tek tek dolaşmaya yarar. dolaşırken 
            //p verileri tek tek gezmemiz için oluşturduğumuz değişken.
            //singleordefault foreach gibi bütün verileri dolaşır.
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products; 
            //business benden bir product(ürün) istiyor bende ürün listesini döndüreceğim.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryId == categoryId).ToList();
            //Where = içinedeki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
            //ToList() anahtar sözcüğü koleksiyonda bulunan verileri list'e dönüştürür.
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Business ten Gönderdiğim ürün id sine sahip listedeki ürün id sini bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //business ten gönderdiklerimi güncelle.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
