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
        #endregion
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

        #region for exception testing
        #endregion
        #endregion

        #region Properties
        #region for valid data
        #endregion
        #region for exception testing
        #endregion
        #endregion

        #region Methods
        #region for valid data
        #endregion
        #region for exception testing
        #endregion
        #endregion
    }
}
