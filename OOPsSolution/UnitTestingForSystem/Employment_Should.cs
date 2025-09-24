using FluentAssertions;
using OOPsReview;
using System.Reflection;

namespace UnitTestingForSystem
{
    public class Employment_Should
    {

        #region Valid Data
        ////the type [Fact] says to run the test once
        [Fact]
        public void Create_New_Default_Instance()
        {
            //Where - Arrange setup
            string expectedTitle = "Unknown";
            SupervisoryLevel expectedLevel = SupervisoryLevel.TeamMember;
            DateTime expectedStartDate = DateTime.Today;
            double expectedYears = 0;

            //When - Act execution
            Employment actual = new Employment();

            //Then - Assert check
            actual.Title.Should().Be(expectedTitle);
            actual.Level.Should().Be(expectedLevel);
            actual.StartDate.Should().Be(expectedStartDate);
            actual.Years.Should().Be(expectedYears);
        }

        [Fact]
        public void Create_New_Greedy_Instance()
        {
            //Where - Arrange setup
            string expectedTitle = "SAS Lead";
            SupervisoryLevel expectedLevel = SupervisoryLevel.TeamLeader;
            DateTime expectedStartDate = new DateTime(2020, 10, 24);
            double expectedYears = 3.6;

            //When - Act execution
            Employment actual = new Employment("  SAS Lead   ", SupervisoryLevel.TeamLeader,
                                                    new DateTime(2020, 10, 24), 3.6);

            //Then - Assert check
            actual.Title.Should().Be(expectedTitle);
            actual.Level.Should().Be(expectedLevel);
            actual.StartDate.Should().Be(expectedStartDate);
            actual.Years.Should().Be(expectedYears);
        }

        //Depending on whether you adjusted the years when the default for years parameter
        //  is used the greedy constructor, this test may or may not work (see note in greedy constructor)
        [Fact]
        public void Create_New_Greedy_Instance_With_Years_Default()
        {
            //Where - Arrange setup
            string expectedTitle = "SAS Lead";
            SupervisoryLevel expectedLevel = SupervisoryLevel.TeamLeader;
            DateTime expectedStartDate = new DateTime(2020, 10, 24);

            //if code not in greedy constructor, expectedYears will be 0.0
            //double expectedYears = 0.0;

            //when the code for calculating the correct years work is in the
            //  code, activate this code and comment out the previous lin of code
            TimeSpan days = DateTime.Today - expectedStartDate;
            double expectedYears = Math.Round((days.Days / 365.2), 1);

            //When - Act execution
            Employment actual = new Employment("  SAS Lead   ", SupervisoryLevel.TeamLeader,
                                                    new DateTime(2020, 10, 24));

            //Then - Assert check
            actual.Title.Should().Be(expectedTitle);
            actual.Level.Should().Be(expectedLevel);
            actual.StartDate.Should().Be(expectedStartDate);
            actual.Years.Should().Be(expectedYears);
        }

        [Fact]
        public void Change_the_Title()
        {
            //Where - Arrange setup
            string Title = "SAS Lead";
            SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
            DateTime StartDate = new DateTime(2020, 10, 24);
            TimeSpan days = DateTime.Today - StartDate;
            double Years = Math.Round((days.Days / 365.2), 1);
            Employment sut = new Employment(Title, Level, StartDate, Years);
            string expectedTitle = "Development Head";

            //When - Act execution
            //sut -> subject under test
            sut.Title ="   Development Head   ";

            //Then - Assert check
            sut.Title.Should().Be(expectedTitle);

        }

        //////DO NOT use if your class demonstration has made Years set private
        [Fact]
        public void Change_the_Years()
        {
            //Where - Arrange setup
            string Title = "SAS Lead";
            SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
            DateTime StartDate = new DateTime(2020, 10, 24);
            TimeSpan days = DateTime.Today - StartDate;
            double Years = Math.Round((days.Days / 365.2), 1);
            Employment sut = new Employment(Title, Level, StartDate, Years);
            double expectedYears = 5.9;

            //When - Act execution
            sut.CorrectStartDate(new DateTime(2019, 10, 24));

            //Then - Assert check
            sut.Years.Should().Be(expectedYears);
        }

        [Fact]
        public void Set_The_SupervisoryLevel()
        {
            //Where - Arrange setup
            string Title = "SAS Lead";
            SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
            DateTime StartDate = new DateTime(2020, 10, 24);
            TimeSpan days = DateTime.Today - StartDate;
            double Years = Math.Round((days.Days / 365.2), 1);
            Employment sut = new Employment(Title, Level, StartDate, Years);
            SupervisoryLevel expectedLevel = SupervisoryLevel.Supervisor;

            //When - Act execution
            sut.SetEmploymentResponsibilityLevel(SupervisoryLevel.Supervisor);

            //Then - Assert check
            sut.Level.Should().Be(expectedLevel);

        }

        [Fact]
        public void Set_The_Correct_StartDate()
        {
            //Where - Arrange setup
            string Title = "SAS Lead";
            SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
            DateTime StartDate = new DateTime(2020, 10, 24);
            TimeSpan days = DateTime.Today - StartDate;
            double Years = Math.Round((days.Days / 365.2), 1);
            Employment sut = new Employment(Title, Level, StartDate, Years);
            DateTime expectedDate = new DateTime(2019, 10, 24);

            //add the generation of the years when the date is updated
            //this assumes that this is the most current employment

            days = DateTime.Today - expectedDate;
            double expectedyears = Math.Round((days.Days / 365.2), 1);

            //When - Act execution
            sut.CorrectStartDate(new DateTime(2019, 10, 24));

            //Then - Assert check
            sut.StartDate.Should().Be(expectedDate);
            sut.Years.Should().Be(expectedyears);
        }


        [Fact]
        public void Create_CSV_String()
        {
            string Title = "SAS Lead";
            SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
            DateTime StartDate = new DateTime(2020, 10, 24);
            TimeSpan days = DateTime.Today - StartDate;
            double Years = Math.Round((days.Days / 365.2), 1);
            Employment sut = new Employment(Title, Level, StartDate, Years);
            string expectedCSV = $"SAS Lead,TeamLeader,Oct 24 2020,{Years}";

            //When - Act execution
            string actual = sut.ToString();

            //Then - Assert check
            actual.Should().Be(expectedCSV);

        }


        #endregion

        #region Invalid Data
        // the type [Theory] requires the test to be run once for each [InlineData]
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Create_New_Greedy_Instance_Throws_Title_Exception(string title)
        {
            //Where - Arrange setup


            //When - Act execution
            Action action = () => new Employment(title, SupervisoryLevel.TeamMember, DateTime.Today, 0.0);

            //Then - Assert check
            action.Should().Throw<ArgumentNullException>();
        }

        ////[Fact]
        ////public void Create_New_Greedy_Instance_Throws_SupervisorLevel_Exception()
        ////{
        ////    //Where - Arrange setup

        ////    //create an invalid enum value 
        ////    SupervisoryLevel level = (SupervisoryLevel)15;


        ////    //When - Act execution
        ////    Action action = () => new Employment("SAS Lead", level, DateTime.Today, 0);

        ////    //Then - Assert check
        ////    action.Should().Throw<ArgumentException>().WithMessage("*15*");
        ////}

        [Fact]
        public void When_Creating_New_Greedy_Instance_Throws_StartDate_Future_Exception()
        {
            //Where - Arrange setup
            DateTime StartDate = DateTime.Parse("4902/10/24");

            //When - Act execution
            Action action = () => new Employment("SAS Lead", SupervisoryLevel.TeamMember, StartDate, 0);

            //Then - Assert check
            action.Should().Throw<ArgumentException>().WithMessage("*future*");
        }

        [Fact]
        public void Create_New_Greedy_Instance_Throws_Negative_Years_Exception()
        {
            //Where - Arrange setup
            double Years = -5.5;

            //When - Act execution
            Action action = () => new Employment("SAS Lead", SupervisoryLevel.TeamMember, DateTime.Today, Years);

            //Then - Assert check
            action.Should().Throw<ArgumentException>().WithMessage($"*{Years}*");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("      ")]
        public void Directly_Change_Title_Throws__Exception(string title)
        {
            //Where - Arrange setup
            Employment sut = new Employment("SAS Lead", SupervisoryLevel.TeamMember, DateTime.Today, 0);

            //When - Act execution
            Action action = () => sut.Title = title;

            //Then - Assert check
            action.Should().Throw<ArgumentNullException>();
        }

        ////DO NOT use if your class demonstration has made Years set private
        [Fact]
        public void Directly_Change_Years_Throws_Exception()
        {
            //Where - Arrange setup
            Employment sut = new Employment("SAS Lead", SupervisoryLevel.TeamMember, DateTime.Today, 0);

            //When - Act execution
            Action action = () => sut.Years = -5.5;

            //Then - Assert check
            action.Should().Throw<ArgumentException>().WithMessage("*-5.5*");
            // action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*-5.5*");
        }

        ////[Fact]
        ////public void Set_The_SupervisoryLevel_Throws_Exception()
        ////{
        ////    //Where - Arrange setup
        ////    string Title = "SAS Lead";
        ////    SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
        ////    DateTime StartDate = new DateTime(2020, 10, 24);
        ////    TimeSpan days = DateTime.Today - StartDate;
        ////    double Years = Math.Round((days.Days / 365.2), 1);
        ////    Employment sut = new Employment(Title, Level, StartDate, Years);
        ////    SupervisoryLevel badLevel = (SupervisoryLevel)15;
        ////    //When - Act execution
        ////    Action action = () => sut.SetEmploymentResponsibilityLevel(badLevel);

        ////    //Then - Assert check
        ////    action.Should().Throw<ArgumentException>().WithMessage("*15*");

        ////}

        [Fact]
        public void Set_The_Correct_StartDate_Throws_Exception()
        {
            //Where - Arrangement setup
            string Title = "SAS Lead";
            SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
            DateTime StartDate = new DateTime(2020, 10, 24);
            TimeSpan days = DateTime.Today - StartDate;
            double Years = Math.Round((days.Days / 365.2), 1);
            Employment sut = new Employment(Title, Level, StartDate, Years);

            //When - Act execution
            Action action = () => sut.CorrectStartDate(new DateTime(2919, 10, 24));

            //Then - Assert check
            action.Should().Throw<ArgumentException>().WithMessage("*future*");

        }
        #endregion
    }
}