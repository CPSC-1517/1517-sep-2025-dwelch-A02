using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;

        public string FirstName 
        { 
            get { return _FirstName; } 
            set { _FirstName = value.Trim(); }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value.Trim(); }
        }
        public ResidentAddress Address { get; set; }

        //when an instance is being created, the o/s will first
        //  generate your storage areas, assign default datatype values,
        //  assign declaration assignment values THEN execute the appropriate constructor
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();
        
        public string FullName
        {
            //get { return LastName + ", " + FirstName; }
            get { return $"{LastName}, {FirstName}"; }
        }
        
        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            //the following line was removed when Refactoring after the greedy constructor test
            //EmploymentPositions = new List<Employment>();
        }
        public Person(string firstname, string lastname,
                    ResidentAddress address, List<Employment> employments)
        {
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentNullException("FirstName","First name cannot be missing or blank");
            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentNullException("LastName", "Last name cannot be missing or blank");
            FirstName = firstname; //.Trim() can be refactored due to the Trim in the property
            LastName = lastname; //.Trim(); refactored
            Address = address;
            if (employments != null)
                //save the list sent in
                EmploymentPositions = employments;
            //the following line was removed when Refactoring after the greedy constructor test
            //else
            //    //parameter has not list instance
            //    EmploymentPositions = new List<Employment>();
        }
    }
}
