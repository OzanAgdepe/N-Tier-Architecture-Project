using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccesLayer.Entity_Framework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo_Product_UI.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        JobManager jobManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var values = customerManager.GetCustomersListWithJob(); //metodların içerisi BL'de Concrete içinde CustomerManagerde dolduruldu
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
           
            List<SelectListItem> values=(from x in jobManager.TGetList()select new SelectListItem
            {
                Text=x.Name,
                Value=x.JobID.ToString()
            }).ToList();
            ViewBag.v=values;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult result = validationRules.Validate(p);


            if (result.IsValid)  //isValid -> verilen şartlar geçerli ise 
            {
                customerManager.TInsert(p);
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
            public IActionResult DeleteCustomer(int id)
        {
            var value = customerManager.TGetById(id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult UpdateCustomer(int id)
        {
            List<SelectListItem> values = (from x in jobManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.JobID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = customerManager.TGetById(id);
            return View(value);
        }
        [HttpPost]

        public IActionResult UpdateCustomer(Customer p)
        {
            customerManager.TUpdate(p);
            return RedirectToAction("Index");
        }

    }
}
