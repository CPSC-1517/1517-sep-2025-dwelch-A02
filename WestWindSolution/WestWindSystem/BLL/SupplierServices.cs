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
    public class SupplierServices
    {
        #region setup of the context connection variable and class constructor
        private readonly WestWindContext _context;

        internal SupplierServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Query Services

        public List<Supplier> Supplier_GetAll()
        {
            IEnumerable<Supplier> info = _context.Suppliers;
           return info.OrderBy(x => x.CompanyName).ToList();
           
        }
        #endregion
    }
}
