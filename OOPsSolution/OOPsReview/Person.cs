using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ResidentAddress Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; }
        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";

        }
    }
}
