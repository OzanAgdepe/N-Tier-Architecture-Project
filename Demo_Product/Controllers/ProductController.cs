using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccesLayer.Entity_Framework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product_UI.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        public IActionResult Index()
        {
            var values = productManager.TGetList();

            return View(values);
        }
        [HttpGet]

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            ProductValidator validationRules = new ProductValidator();  //ProductValidatoru çağırıp validitonRules adı altında nesne türettik
            ValidationResult result = validationRules.Validate(p);  // Burda validationresulst nesnesini kullanmamız gerekiyor. / parametreye verdiğimiz değerin 
                                                                    // productvalidatior daki şartları sağlayıp sağlamadığını kontrol ediyoruz
            if (result.IsValid)  //isValid -> verilen şartlar geçerli ise 
            {
                productManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)  //Sonucun hataları
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //hatanın keyini ve hata mesajını döndür(Hangi propertyde hata var ve bu hatanın detaylarını ekler)
                }
            }
            return View();

        }

        public IActionResult DeleteProduct(int id)
        {
            var value=productManager.TGetById(id);
            productManager.TDelete(value);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = productManager.TGetById(id);
            
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            //var value = productManager.TGetById(p.Id);
            productManager.TUpdate(p);
            return RedirectToAction("Index");
        }
            

        }
    } 





    

