using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IGenericDal<T> where T : class  // T İSİMLİ ENTİTY TANIMLADIK
    {
        void Insert(T t);  // "T" isimli entityden türeyen bir "t" Parametresi al dedik...
        void Delete(T t);
        void Update(T t);
        List<T> GetList();

        T GetById(int id);   //ID'e göre getir anlamını taşıyan bir metod tanımladık. Dışardan İd parametresi alacak
    }
}
