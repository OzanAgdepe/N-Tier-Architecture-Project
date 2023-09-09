using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Absctact
{
    public interface IGenericService<T>  // burası kontrolleri yapacağımız kısım olacak. Örneğin ürün adı girerken 20 karakteri geçmesin gibi
                                        //Entity için GenericService yazdık  // BL'de Abstract ifadeler "Service" -  Concrate ifadeler "Manager" Eki alır
    {
        void TInsert(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetById(int id);



    }
}
