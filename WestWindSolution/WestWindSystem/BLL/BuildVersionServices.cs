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
    public class BuildVersionServices
    {
        #region setup of the context connection variable and class constructor

        //this class will create an instance of the WestWindContext class
        //  everytime that the services is used by the outside user

        //any method (aka service) will probably need access to our database
        //this will be done via the context class (WestWindContext)
        //during the instantiation of this service class, we will create
        //  an instance of the context class
        //we will save this instance in a private variable usable throughout the class
        //during the instantiation of this service class the constructor will
        //  receive as a parameter the registered connection from the IServiceCollection

        private readonly WestWindContext _context;

        internal BuildVersionServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Query Services
        /*********************** Services *****************************/
        // a service is a method
        //this class will be referenced by external users (aka web app)
        //therefore the class and the services need to be public
        public BuildVersion BuildVersion_Get()
        {
            //get the data from the database via the context class property
            /*
            * this will use the context property BuildVersions to obtain the
            *      data from the database via the context class
            *  the call return the dataset (DbSet) from the sql table
            *  data returned by the query in this fashion is returned as a set
            *      with the datatype of IEnumerable<T>, where T is the
            *      name of the entity
            *  the dataset create will contain 0, 1 or more records, one for
            *      each row on your sql table
            */
            //get the data from the database as a collection of records
            IEnumerable<BuildVersion> info = _context.BuildVersions;

            //extract a record from the DbSet collection
            /*
             * data returned is one row from the data placed within info
             * Linq/built-in collection methtods has a method that limits the number of rows from a
             *      data collection: .FirstOrDefault()
             * this method will return the first record in the dataset collection
             * if the collection is empty it will return the default of the datatype
             *  (in this case, it is an instance of a class, thus the default is null)
             */
            return info.FirstOrDefault();
        }
        #endregion
    }
}
