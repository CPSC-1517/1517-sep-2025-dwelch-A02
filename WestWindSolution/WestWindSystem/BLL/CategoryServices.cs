using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class CategoryServices
    {
        #region setup of the context connection variable and class constructor
        private readonly WestWindContext _context;

        internal CategoryServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Query Services

        public List<Category> Category_GetAll()
        {
            IEnumerable<Category> info = _context.Categories;
            return info.OrderBy(x => x.CategoryName).ToList();
        }
        #endregion
    }
}
