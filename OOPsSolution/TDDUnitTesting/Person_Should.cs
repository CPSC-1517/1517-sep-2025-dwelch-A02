using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add the necessary using classes to your required namespaces
using OOPsReview;
using FluentAssertions;

namespace TDDUnitTesting
{
    public class Person_Should
    {
        #region Constructors
        #region for valid data
        //a Fact unit test executes once
        //without the [Fact] annotation, the method is NOT considered a unit test
        //  it would just be a method within this class
        [Fact]
        public void Successfully_Create_An_Instance_Using_the_Default_Constructor()
        {
            //Arrange (this is the setup of values need for doing the test)
            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";
            int expectedEmploymentPositionCount = 0;

            //Act (this is the action that is under testing)
            //sut: subject under test
            //Image that the Act is a line of code from a program
            Person sut = new Person();

            //Assert (check the results of the act (Act) against expected Values (Arrange))
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);
        }

        [Fact]
        public void Successfully_Create_An_Instance_Using_Greedy_Constructor_With_No_Address_Or_Employments()
        {
            //Arrange 
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";
            int expectedEmploymentPositionCount = 0;

            //Act 
            Person sut = new Person("  Don ","   Welch  ",null,null);

            //Assert 
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);
        }

        [Fact]
        public void Successfully_Create_An_Instance_Using_Greedy_Constructor_With_No_Employments()
        {
            //Arrange 
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";
            ResidentAddress expectedAddress = new ResidentAddress(123, "Maple St.",
                                "Edmonton", "AB", "T6Y7U8");
            int expectedEmploymentPositionCount = 0;

            //Act 
            Person sut = new Person("  Don ", "   Welch  ", expectedAddress, null);

            //Assert 
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().Be(expectedAddress);
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);
        }

        [Fact]
        public void Successfully_Create_An_Instance_Using_Greedy_Constructor_With_All_Data()
        {
            //Arrange 
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";
            ResidentAddress expectedAddress = new ResidentAddress(123, "Maple St.",
                                "Edmonton", "AB", "T6Y7U8");

            //how to test a collection?
            //create individual instances of the item in the list
            //in this example those instances are objects
            //you must remember each object has a unique GUID
            //NOTE: you CANNOT reuse a single variable to hold the separate instances
            Employment one = new Employment("PG I", SupervisoryLevel.TeamMember,
                                        DateTime.Parse("2013/10/10"), 6.5);
            //remember that if no year was supplied the length of holding the current
            //      position is calculated for the instance
            Employment two = new Employment("PG II", SupervisoryLevel.TeamLeader,
                                DateTime.Parse("2020/10/10"));
            List<Employment> employments = new List<Employment>();
            employments.Add(one);
            employments.Add(two);
            int expectedEmploymentPositionCount = 2;

            //Act 
            Person sut = new Person("  Don ", "   Welch  ", expectedAddress, employments);

            //Assert 
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().Be(expectedAddress);
            //best practise to check the count of your list before checking the contents
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);
            //what about the collection itself
            // - it has to have the correct instances
            // - the instances should be in the same physical order
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(employments);
        }
        #endregion


        #region for exception testing
        //the second test annotation used is called [Theory]
        //it will execute n number of times as a loop
        //n is determined by the number [InlineData()] annotations following the [Theory]
        //to setup the test header, you must include a parameter in a parameter list
        //  one for each, value in the InlineData set of values
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_Creating_Instance_Using_Greedy_Constructor_For_Missing_FirstName(string firstname)
        {
            //Arrange
            //possible values for FirstName: null, empty string, blank string
            //the setup of an exception test does not have to be as extensive as a successful test
            //  as the objective is to catch the exception that is thrown
            //in this example there will be no need to check expected values

            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => new Person(firstname, "Welch", null, null);

            //Assert
            //test to see if the expected exception was throw
            action.Should().Throw<ArgumentNullException>();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_Creating_Instance_Using_Greedy_Constructor_For_Missing_LastName(string lastname)
        {
            //Arrange
            //possible values for FirstName: null, empty string, blank string
            //the setup of an exception test does not have to be as extensive as a successful test
            //  as the objective is to catch the exception that is thrown
            //in this example there will be no need to check expected values

            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => new Person("Don", lastname, null, null);

            //Assert
            //test to see if the expected exception was throw
            action.Should().Throw<ArgumentNullException>();
        }

        //combine the two previous Theory tests
        //multiple values in InlinData
        //multiple parameters on your method
        [Theory]
        
        [InlineData(null,"Welch")]
        [InlineData("","Welch")]
        [InlineData("    ","Welch")]
        [InlineData("Don",null)]
        [InlineData("Don","")]
        [InlineData("Don","    ")]
        public void Throw_Exception_Creating_Instance_Using_Greedy_Constructor_For_Missing_First_Or_Last_Name(string firstname,string lastname)
        {
            //Arrange
            //possible values for FirstName: null, empty string, blank string
            //the setup of an exception test does not have to be as extensive as a successful test
            //  as the objective is to catch the exception that is thrown
            //in this example there will be no need to check expected values

            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            Action action = () => new Person(firstname, lastname, null, null);

            //Assert
            //test to see if the expected exception was throw
            action.Should().Throw<ArgumentNullException>();
        }
        #endregion
        #endregion

        #region Properties
        #region for valid data
        //successfully change the FirstName on a instance of Person
        //  via the Property
        [Fact]
        public void Successfully_Change_FirstName_Via_Property()
        {
            //Arrange
            string expectedFirstName = "Don";
            //Person sut = new Person(); //default firstname is Unknown
            Person sut = new Person("Lowand", "Behold", null, null);

            //Act
            sut.FirstName = "  Don   ";

            //Assert
            sut.FirstName.Should().Be(expectedFirstName);

        }
        //successfully change the LastName on a instance of Person
        //  via the Property
        [Fact]
        public void Successfully_Change_LastName_Via_Property()
        {
            //Arrange
            string expectedLastName = "Welch";
            //Person sut = new Person(); //default firstname is Unknown
            Person sut = new Person("Lowand", "Behold", null, null);

            //Act
            sut.LastName = "  Welch   ";

            //Assert
            sut.LastName.Should().Be(expectedLastName);

        }
        //successfully change the Address on a instance of Person
        //  via the Property
        [Fact]
        public void Successfully_Change_Address_Via_Property()
        {
            //Arrange
            ResidentAddress expectedAddress = new ResidentAddress(321, "Oaklane Ave",
                                    "St, Albert", "AB", "T4E3W2");
            Person sut = new Person("Lowand", "Behold", 
                        new ResidentAddress(123, "Maple St.", "Edmonton", "AB", "T6Y7U8"),null);

            //Act
            sut.Address = new ResidentAddress(321, "Oaklane Ave",
                                    "St, Albert", "AB", "T4E3W2");

            //Assert
            sut.Address.Should().Be(expectedAddress);
        }

        //your current home burns down, you get evicted, etc.
        [Fact]
        public void Successfully_Change_Address_To_Null_Via_Property()
        {
            //Arrange
            
            Person sut = new Person("Lowand", "Behold",
                        new ResidentAddress(123, "Maple St.", "Edmonton", "AB", "T6Y7U8"), null);

            //Act
            sut.Address = null;

            //Assert
            sut.Address.Should().BeNull();
        }

        //successfully return the person's fullname from an instance
        //          via a property; format last, first
        [Fact]
        public void Successfully_Return_FullName_Via_Property()
        {
            //Arrange
            string expectedFullName = "Ujest, Shirley";
            Person sut = new Person("Shirley", "Ujest", null, null);


            //Act
            string fullname = sut.FullName;

            //Assert
            fullname.Should().Be(expectedFullName);

        }
        #endregion
        #region for exception testing
        //throw ArgumentNullException if first name is missing while change via the property
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("      ")]
        public void Throw_Exception_Directly_Changing_FirstName_Via_Property_With_Missing_Data(string firstname)
        {
            //Where - Arrange setup
            Person sut = new Person("Don", "Welch", null, null);

            //When - Act execution
            Action action = () => sut.FirstName = firstname;

            //Then - Assert check
            action.Should().Throw<ArgumentNullException>();
        }

        //throw ArgumentNullException if last name is missing while change via the property
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("      ")]
        public void Throw_Exception_Directly_Changing_LastName_Via_Property_With_Missing_Data(string lastname)
        {
            //Where - Arrange setup
            Person sut = new Person("Don", "Welch", null, null);

            //When - Act execution
            Action action = () => sut.LastName = lastname;

            //Then - Assert check
            action.Should().Throw<ArgumentNullException>();
        }

        #endregion
        #endregion

        #region Methods
        #region for valid data
        //person's fullname (first and last) should be able to be changed in one method
        [Fact]
        public void Succesfully_Change_FullName_At_One_Time()
        {
            //Arrange
            string expectedFullName = "Behold, Lowand";
            Person sut = new Person("Shirley", "Ujest", null, null);

            //Act
            sut.ChangeFullName("Lowand", "Behold");

            //Assert
            sut.FullName.Should().Be(expectedFullName);
        }

        //successfully add the first instance of employment to the person
        [Fact]
        public void Successfully_Add_First_Employment()
        {
            //Arrange
            //data needed
            Person sut = new Person("Shirley", "Ujest", null, null);

            //data needed for act
            Employment newemployment = new Employment("PG II", SupervisoryLevel.TeamLeader,
                                DateTime.Parse("2020/10/10"));
            int expectedEmploymentPositionsCount = 1;
            List<Employment> expectedEmployments = new List<Employment>();
            expectedEmployments.Add(newemployment);

            //Act
            sut.AddEmployment(newemployment);

            //Assert
            //best practise to check the count of your list before checking the contents
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionsCount);
            //what about the collection itself
            // - it has to have the correct instances
            // - the instances should be in the same physical order
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedEmployments);
        }

        //successfully add another instance of employment to the person
        [Fact]
        public void Successfully_Add_The_Next_Employment()
        {
            //Arrange
            //data needed
            Employment one = new Employment("PG I", SupervisoryLevel.TeamMember,
                               DateTime.Parse("2013/10/10"),6.5);
            Employment two = new Employment("PG II", SupervisoryLevel.TeamLeader,
                               DateTime.Parse("2020/10/10"));
            List<Employment> existingEmployments = new List<Employment>();
            existingEmployments.Add(one);
            existingEmployments.Add(two);
            Person sut = new Person("Shirley", "Ujest", null, existingEmployments);

            //data needed for act
            Employment newemployment = new Employment("Sup I", SupervisoryLevel.Supervisor,
                                DateTime.Today);
            
            List<Employment> expectedEmployments = new List<Employment>();
            //when creating your expected collection you need to add
            //      any existing records of your original collection
            expectedEmployments.Add(one);
            expectedEmployments.Add(two);
            expectedEmployments.Add(newemployment);

            //Act
            sut.AddEmployment(newemployment);

            //Assert
            //best practise to check the count of your list before checking the contents
            sut.EmploymentPositions.Count().Should().Be(expectedEmployments.Count);
            //what about the collection itself
            // - it has to have the correct instances
            // - the instances should be in the same physical order
         
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedEmployments);
        }
        #endregion
        #region for exception testing
        [Theory]
        [InlineData(null,"Welch")]
        [InlineData("", "Welch")]
        [InlineData("      ", "Welch")]
        [InlineData("Don",null)]
        [InlineData("Don","")]
        [InlineData("Don", "    ")]
        public void Throw_Exception_Changing_FulltName_Via_Method_With_Missing_Data(string firstname, string lastname)
        {
            //Where - Arrange setup
            Person sut = new Person("Don", "Welch", null, null);

            //When - Act execution
            Action action = () => sut.ChangeFullName(firstname, lastname);

            //Then - Assert check
            action.Should().Throw<ArgumentNullException>();
        }

        //when no employment data sent to method
        [Fact]
        public void Throw_Exception_When_Missing_Employment_Data_During_AddEmployment()
        {
            //Arrange
            //data needed
            Person sut = new Person("Shirley", "Ujest", null, null);

          
            //Act
            Action action = () => sut.AddEmployment(null);

            //Assert
            //one can test the contents of the error message being thrown
            //this is done using the .WithMessage(string)
            //a substring of the error message can be check using *.....* for the string
            //one can use string interpolation with the creation of the string
            action.Should().Throw<ArgumentNullException>().WithMessage("*Missing data*");
        }

        //any duplicate employment records should not be accepted
        [Fact]
        public void Throw_Exception_When_Adding_Duplicate_Employment_Instance()
        {
            //Arrange
            //data needed
            Employment one = new Employment("PG I", SupervisoryLevel.TeamMember,
                               DateTime.Parse("2013/10/10"), 6.5);
            Employment two = new Employment("PG II", SupervisoryLevel.TeamLeader,
                               DateTime.Parse("2020/10/10"));
            Employment newemployment = new Employment("Sup I", SupervisoryLevel.Supervisor,
                              DateTime.Today);
            List<Employment> existingEmployments = new List<Employment>();
            existingEmployments.Add(one);
            existingEmployments.Add(two);
            Person sut = new Person("Shirley", "Ujest", null, existingEmployments);



            //Act
            Action action = () => sut.AddEmployment(two);

            //Assert
            action.Should().Throw<ArgumentException>().WithMessage($"*{two.Title} on {two.StartDate}*");
        }
        #endregion
        #endregion

    }
}
