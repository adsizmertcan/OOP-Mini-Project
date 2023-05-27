using DataAccessLayer.Abstract;
using DataAccessLayer.GenericReporitories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal:GenericRepository<Category>,ICategoryDal
    {
    }
}
