using BusinessLayer.Absctact;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService  // IProductService GenericService'dan miras aldığı için burda da onu çağırdığımız için GenericService özellijkeri geldi
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal) //constructor metod --> bulunduğu sınıf ile aynı ismi alan metod
        {
            _productDal = productDal;
        }

        public void TDelete(Product t)
        {
            
            _productDal.Delete(t);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public void TInsert(Product t)
        {
            _productDal.Insert(t);
        
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
