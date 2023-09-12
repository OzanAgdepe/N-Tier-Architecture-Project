using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entity_Framework
{
    public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
    {
        public List<Customer> GetCustomerListWithJob()
        {
            using (var c =new Context())
            {
                return c.Customers.Include(x=>x.Job).ToList();
            }
        }
    }
}
