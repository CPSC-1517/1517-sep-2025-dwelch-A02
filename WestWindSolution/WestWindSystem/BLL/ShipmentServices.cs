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
    public class ShipmentServices
    {
        #region setup of the context connection variable and class constructor
        private readonly WestWindContext _context;

        internal ShipmentServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Query Services
        //return all shipments for a particular year/month
        public List<Shipment> Shipment_GetByYearandMonth(int year, int month)
        {
            //Can one do validation within the service? Yes
            //Why: hackers could change the service packet before leaving the
            //      the browser
            if(year < 1950 || year > DateTime.Today.Year)
            {
                throw new ArgumentException($"Year {year} is invalid. Year must be between 1950 and today.");
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentException($"Month {month} is invalid. Month must be between 1 and 12.");
            }

            //attempt to retrieve data from the database
            IEnumerable<Shipment> info = _context.Shipments
                                                .Where(x => x.ShippedDate.Year == year
                                                        && x.ShippedDate.Month == month)
                                                .OrderBy(x => x.ShippedDate);
            return info.ToList();
        }
        #endregion
    }
}
