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
    public class RegionServices
    {
        #region setup of the context connection variable and class constructor
        private readonly WestWindContext _context;

        internal RegionServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Query Services

        //first query will be used to retrieve all the records of the
        //      entity so they may be used in a select control on the
        //      web page
        //this should ONLY be considered IF the entity has very few records (consider 100 as a max)
        //this can be considered IF you need the data as part of your
        //      foreign key display handling on your web page

        //remember methods are your services.
        public List<Region> Region_GetAll()
        {
            //by default the two generic collections used by Linq (Language Integraded Query)
            //  are IQueryAble and IEnumerable
            //within your C# the collection is IEnumerable<T>

            //create a variable to catch the data returned from the
            //  DAL context DbSet property associated with the
            //  Region entity (aka table)
            //
            //the call consists of the context class instance (which is an object)
            //  and the DbSet and optionally any additional Linq methods

            IEnumerable<Region> info = _context.Regions; //all records, unsorted

            //send back an ordered list of regions
            //the collection info is being passed to a Linq method called OrderBy()
            //the OrderBy() method will return a temporary collection
            //      and can be passed to the next method
            //the temporary collection is being passed to the ToList() method
            //the ToList() method will return a List<T> collection
            //that collection is returned from the service method

            //.OrderBy() ascending 1st ordering attribute
            //.OrderDescendingBy() descending 1st ordering attribute
            //.ThenBy() ascending for each additional ordering attribute
            //.ThenDescendingBy() descending for each additional ordering attribute
            //YES: these can be mixed and matched
            return info.OrderBy(x => x.RegionDescription).ToList();
        }

        //looking up a single record given a specific value
        public Region Region_GetByID(int regionid)
        {
            Region info = null;

            //the code within the FirstOrDefault is a predicate
            //the predicate is the condition that is applied to during the methods actions
            //the predicate for this method is the condition to match to find the desired record

            //since the query is based on the pkey of the table, only one record,
            //      if any, should be found
            info = _context.Regions.FirstOrDefault(x => x.RegionID == regionid);
            return info;

            //an alternate way of coding the query
            //notice that the Linq methods can be broken up onto their own lines
            //info = _context.Regions
            //                .Where(x => x.RegionID == regionid)
            //                .FirstOrDefault();
            //return info;

            //an alternate way of coding the query
            //IEnumerable<Region> infoset = _context.Regions
            //                                     .Where(x => x.RegionID == regionid);
            //return infoset.FirstOrDefault();

            // an alternate way of coding the query
            // .Find() searches primary keys therefore just needs the incoming argument
            // since our search is on the primary key, we can use this method
            //return _context.Regions.Find(regionid);
        }
        #endregion
    }
}
