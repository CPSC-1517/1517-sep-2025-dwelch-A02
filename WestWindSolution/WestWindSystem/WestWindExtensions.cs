
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.DAL;
#endregion

namespace WestWindSystem
{
    public static class WestWindExtensions
    {
        //this class can hold an set of extension methods
        //this sample creates an extension method that will add services
        //  to IServiceCollection
        //this method will be called from an separate project to
        //  gain data from the WestWind database
        //In this demo, the call will be done in the WestWindApp Program.cs file
        //this method will do 2 things:
        //  a) register the context connection string
        //  b) register ALL services that I create within the BLL class(es)

        public static void WestWindExtensionServices(this IServiceCollection services,
                Action<DbContextOptionsBuilder> options)
        {
            //handle the connection string
            //add my context class to the services (IServiceCollection)
            //we wish it to use the string I send in on each creation of the
            //      instance of my DbContext class
            services.AddDbContext<WestWindContext>(options);
        }
    }
}
