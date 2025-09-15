using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public record ResidentAddress(int Number, string Street,
                            string City, string Province, string PostalCode)
    {
        //this is a new datatype for .Net Core behaves very much like a class
        //the fields are listed on the declaration (these are the field names 
        //  to use to access data from the instance)
        //this is a read only version of a class
        //when declaring an instance you must pass in the data to be held
        //you CANNOT alter the record instance
        //if you need to alter the data within the instance you must
        //      create a new instance and pass the data to the new instance

        //OPTIONALLY!!!!
        //you can add your own greedy constructor BUT the data values to be
        //      store are the items on the record delcaration
        //      if you wish data validation it would have to be place in the 
        //      constructor you coded.
        //the constructor MUST have the same parameter list
        //you can add methods to this datatype THAT DO NOT alter the data values
        //these methods are returning a data value

        public override string ToString()
        {
            return $"{Number},{Street},{City},{Province},{PostalCode}";
        }
    }
}
