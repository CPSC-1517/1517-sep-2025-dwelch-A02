using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {
        //data members
        //aka fields, variables, attributes
        //typically data members are private and hold data for use
        //  within your class
        //usually associated with a property
        //a data member does not have any built-in validation
        private string _Title;
        private double _Years;

        //properties
        //are associated with a single piece of data.
        //Properties can be implemented by:
        //  a) fully implemented property
        //  b) auto implemented property

        //A property does not need to store data
        //  this type of property is referred to as a read-only
        //  this property typically uses existing data values
        //      within the instance to return a computed value 
        // NOTE there would be NO set for the property

        //Assume two data fields _FirstName and _LastName
        //public string FullName
        //{
        //    get { return _FastName + " " + _LastName; }
        //}

        //fully implemented property
        //fully implemented properties usually has additional logic
        //  to execute for control over the data: such as validation
        //fully implemented properties will have a declared data
        //  member to store the data into

        ///<summary>
        ///Property: Title
        ///datatype: string
        ///validation: there must be a character in the string
        ///a property will always have a getter (accessor)
        ///a property may or maynot have a setter (mutator)
        /// no mutator the property is consider "read-only" and is
        ///         usually returning a computed field
        /// has a mutator, the property will at some point save the data
        ///     to storage
        /// the mutator may be public (default) or private
        ///     public: accessible by outside users of the class
        ///     private: accessible ONLY within the class, usually
        ///                 via the constructor or a method
        /// !!!!! a property DOES NOT have ANY declared incoming parameters !!!!!!
        /// </summary>
        /// 


        //string mytitle = myinstance.Title;

        public string Title
        {
            get 
            {
                //accessor (getter)
                //returns the string associated with this property
                return _Title;
            }
            set 
            {
                //mutator (setter)
                //it is within the set that the validation of the data
                //  is done to determine if the data is acceptable
                //if all processing of the string is done via the property
                //  it will ensure that good data is within the associated string
                if (string.IsNullOrWhiteSpace(value))
                {
                    //classes typically do not write to the console.
                    //classes will throw Exceptions that must be handled in a 
                    //  user friendly fashion by the outside user
                    throw new ArgumentException("Title", "Title may not be empty or blank.");
                }
                else
                {
                    //it is a very good practice to remove leading and trailing spaces on strings
                    //  so that only the required and important characters are stored.
                    //to do this sanitization use .Trim()
                    _Title = value.Trim();
                }
            }
        }

        ///<summary>
        ///Property: Years
        ///validation: the value must be 0 or greater
        ///datatype: double
        ///</summary>
        ///


        //constructors


        //methods


    }
}
