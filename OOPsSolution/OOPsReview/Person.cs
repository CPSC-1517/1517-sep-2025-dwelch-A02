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
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("FirstName", "First name cannot be missing or blank.");
                _FirstName = value.Trim(); 
            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("LastName", "Last name cannot be missing or blank.");
                _LastName = value.Trim();
            }
        }
        public ResidentAddress Address { get; set; }

        //when an instance is being created, the o/s will first
        //  generate your storage areas, assign default datatype values,
        //  assign declaration assignment values THEN execute the appropriate constructor

        // a private set means that no outside user can alter this property directly.
        public List<Employment> EmploymentPositions { get; private set; } = new List<Employment>();
        
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

            //once the validation is placed into the property,  Refactoring, discovers that the
            //  code in the constructor is not required. The code can be removed
            //if (string.IsNullOrWhiteSpace(firstname))
            //    throw new ArgumentNullException("FirstName","First name cannot be missing or blank");

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

        public void ChangeFullName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public void AddEmployment(Employment employment)
        {
            if (employment == null)
                throw new ArgumentNullException("Employment","No employment supplied, missing data");
            
            //one could code a loop to examine each item in the collection to determine if there
            //  is a duplicate history instance
            //However, lets used methods that have already been built to do searching of a collection
            //First step: determine if you need a copy of the instance
            //  in this case: only the knowledge that an instance exist is needed
            //  (do not actual need the instance)
            //  condition: only at least one needs to exist: .Any()

            //within the method one can place one or more delegates (conditions) that
            //  determine if the action is true or false
            //delegate syntax structure:
            //      collectionplaceholderlabel => collectionplaceholderlabel[.property] [condition] value 
            //                  [ && or || another condition ...]
            //typically the collectionplaceholderlabel is very short such x
            //the collectionplaceholderlabel represents any instance in your collection at any time
            
            if(EmploymentPositions.Any(x => x.Title == employment.Title
                                        && x.StartDate.Equals(employment.StartDate)))
            {
                throw new ArgumentException($"Duplicate employment: {employment.Title} on {employment.StartDate}","Employment");
            }
            
            EmploymentPositions.Add(employment);
        }
    }
}
