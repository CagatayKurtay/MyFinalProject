using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{    //Generic yapı---- class=Referans Tip----IEntity=IEntity olabilir nesne de olabilir
    //IEntity newlenemeyeceği için IEntityi kısıtlamış olduk
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null); //Filitreler yazabilmemizi sağlayan kod blogudur.
        T Get(Expression<Func<T, bool>> filter);        //filter vermek zorunludur verilmezse tüm data gelir
        void Add(T product);
        void Update(T product);
        void Delete(T product);

        //Core katmanı diğer katmanları referans almaz

    }
}
