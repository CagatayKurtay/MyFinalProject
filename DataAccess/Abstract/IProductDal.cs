using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{ //interface public değildir operasyonları publictir. //4
    public interface IProductDal:IEntityRepository<Product>  //Code Refactoring
    {

        List<ProductDetailDto> GetProductDetails();
    }
 }
