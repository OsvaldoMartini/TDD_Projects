using System;
using Moq;
using NUnit.Framework;
using CalculatorLibrary.Concrete;
using CalculatorLibrary.Interfaces;

namespace JSON_Parse_Test
{
    /*Summary
       Defining the Interfaces and Classes
       JSON File Response From WebServices
       good data (good path)
       {"result":{"sunrise":"6:37:49 AM","sunset":"4:42:49 PM","solar_noon":"11:40:19 AM","day_length":"10:05:00.1530000"},"status":"OK"}
          
       * good data (sad path)
       {"results":null,"status":"ERROR"}
       */

    [TestFixture]
    public class JSONServiceParseTest
    {

       string goodData =  "{\"result\":{\"sunrise\":\"6:37:49 AM\",\"sunset\":\"4:42:49 PM\",\"solar_noon\":\"11:40:19 AM\",\"day_length\":\"10:05:00.1530000\"},\"status\":\"OK\"}";
       string badData = "{\"results\":null,\"status\":\"ERROR\"}";

 
        [Test]
        public void ServiceSunsetCalculator_ImplementsISunsetCalculator()
        {
            //Arrange values to Initiate de TDD
            var srvSunsetCalculator = new Calculator();
            
            //Actions and/or Methods

            //Assert
            Assert.IsInstanceOf<ICalculator>(srvSunsetCalculator);
        }

        [Test]
        public void ParseJSonSunsetValue_OnGoodData_ReturnExpectedString()
        {
            //Arrange values  - Expected
            string expected = "4:42:49 PM";
            //Action
            string result = Calculator.ParseSunset(goodData);
            //Assert
            Assert.AreEqual(expected,result);
        }


        [Test]
        public void ParseJSonSunsetValue_OnBadData_ThrowArgumentException()
        {
            //Arrange values  - Expected
            
            //Action
            try
            {
                string result = Calculator.ParseSunset(badData);
                Assert.Fail("ArgumentException was not thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.Pass();
            }
            
            //Assert
        }

        [Test]
        public void ToLocalTime_OnValidValue_ReturnExpectedDateTime()
        {
            //Arrange
            string timeString = "4:42:49 PM";
            DateTime date = new DateTime(2016, 09, 10);
            DateTime expected = new DateTime(2016, 09, 10, 16, 42, 49);
            
            //Action
            DateTime result = Calculator.ToLocalTime(timeString, date);

            //Assert
            Assert.AreEqual(expected, result);

        }


        [Test]
        public void GetSunset_OnValidDate_ReturnExpectedDateTime()
        {
            //I am Violating the DRY principle Here ALL the Time
            //Don’t-Repeat-Yourself (DRY) design principle

            //Arrange
            //Create in Memory Fake Object and Use this isolate object
            //In a Mock Obj, I wanna tell it What I want to do,  when I expected to do when I call a particular Method
            var serviceMock = new Mock<IGetServices>();
            serviceMock.Setup(s => s.GetServiceDate(It.IsAny<DateTime>())).Returns(goodData);

            DateTime date = new DateTime(2016, 09, 10);
            DateTime expected = new DateTime(2016, 09, 10, 16, 42, 49);
            
            //Action
            var calculator = new Calculator();
            
            //This Is the Magic tha Mock Do
            calculator.Service = serviceMock.Object;

            var result = calculator.GetSunset(date);

            //Assert
            Assert.AreEqual(expected, result);

        }
        
        
        [Test]
        //[TestCase("", 2770),TestCaseSource("dataHackerHank_1")]  //This Not work
        //string dataHackerHank_1 = "{\"page\":1,\"per_page\":10,\"total\":2770,\"total_pages\":277,\"data\":[{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BYzE4NTRmMDYtNWYzYi00YmNkLTk4NDEtYjFmMDc4ODQ3ODY2XkEyXkFqcGdeQXVyNTUyMzE4Mzg@._V1_SX300.jpg\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":1995,\"imdbID\":\"tt0114898\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"game\",\"Year\":1995,\"imdbID\":\"tt0189200\"},{\"Poster\":\"N/A\",\"Title\":\"The Making of 'Waterworld'\",\"Type\":\"movie\",\"Year\":1995,\"imdbID\":\"tt2670548\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld 4: History of the Islands\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0161077\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"game\",\"Year\":1997,\"imdbID\":\"tt0455840\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0390617\"},{\"Poster\":\"N/A\",\"Title\":\"Swordquest: Waterworld\",\"Type\":\"game\",\"Year\":1983,\"imdbID\":\"tt2761086\"},{\"Poster\":\"N/A\",\"Title\":\"Behind the Scenes of the Most Fascinating Waterworld on Earth: The Great Backwaters, Kerala.\",\"Type\":\"movie\",\"Year\":2014,\"imdbID\":\"tt5847056\"},{\"Poster\":\"N/A\",\"Title\":\"Louise's Waterworld\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0298417\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":2001,\"imdbID\":\"tt0381702\"}]}";
        
        [TestCase("", 2770, "{\"page\":1,\"per_page\":10,\"total\":2770,\"total_pages\":277,\"data\":[{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BYzE4NTRmMDYtNWYzYi00YmNkLTk4NDEtYjFmMDc4ODQ3ODY2XkEyXkFqcGdeQXVyNTUyMzE4Mzg@._V1_SX300.jpg\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":1995,\"imdbID\":\"tt0114898\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"game\",\"Year\":1995,\"imdbID\":\"tt0189200\"},{\"Poster\":\"N/A\",\"Title\":\"The Making of 'Waterworld'\",\"Type\":\"movie\",\"Year\":1995,\"imdbID\":\"tt2670548\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld 4: History of the Islands\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0161077\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"game\",\"Year\":1997,\"imdbID\":\"tt0455840\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0390617\"},{\"Poster\":\"N/A\",\"Title\":\"Swordquest: Waterworld\",\"Type\":\"game\",\"Year\":1983,\"imdbID\":\"tt2761086\"},{\"Poster\":\"N/A\",\"Title\":\"Behind the Scenes of the Most Fascinating Waterworld on Earth: The Great Backwaters, Kerala.\",\"Type\":\"movie\",\"Year\":2014,\"imdbID\":\"tt5847056\"},{\"Poster\":\"N/A\",\"Title\":\"Louise's Waterworld\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0298417\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":2001,\"imdbID\":\"tt0381702\"}]}")]
        [TestCase("Waterworld", 11, "{\"page\":1,\"per_page\":10,\"total\":11,\"total_pages\":2,\"data\":[{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BYzE4NTRmMDYtNWYzYi00YmNkLTk4NDEtYjFmMDc4ODQ3ODY2XkEyXkFqcGdeQXVyNTUyMzE4Mzg@._V1_SX300.jpg\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":1995,\"imdbID\":\"tt0114898\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"game\",\"Year\":1995,\"imdbID\":\"tt0189200\"},{\"Poster\":\"N/A\",\"Title\":\"The Making of 'Waterworld'\",\"Type\":\"movie\",\"Year\":1995,\"imdbID\":\"tt2670548\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld 4: History of the Islands\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0161077\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"game\",\"Year\":1997,\"imdbID\":\"tt0455840\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0390617\"},{\"Poster\":\"N/A\",\"Title\":\"Swordquest: Waterworld\",\"Type\":\"game\",\"Year\":1983,\"imdbID\":\"tt2761086\"},{\"Poster\":\"N/A\",\"Title\":\"Behind the Scenes of the Most Fascinating Waterworld on Earth: The Great Backwaters, Kerala.\",\"Type\":\"movie\",\"Year\":2014,\"imdbID\":\"tt5847056\"},{\"Poster\":\"N/A\",\"Title\":\"Louise's Waterworld\",\"Type\":\"movie\",\"Year\":1997,\"imdbID\":\"tt0298417\"},{\"Poster\":\"N/A\",\"Title\":\"Waterworld\",\"Type\":\"movie\",\"Year\":2001,\"imdbID\":\"tt0381702\"}]}")]
        [TestCase("Maze", 97, "{\"page\":1,\"per_page\":10,\"total\":97,\"total_pages\":10,\"data\":[{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BMjUyNTA3MTAyM15BMl5BanBnXkFtZTgwOTEyMTkyMjE@._V1_SX300.jpg\",\"Title\":\"The Maze Runner\",\"Type\":\"movie\",\"Year\":2014,\"imdbID\":\"tt1790864\"},{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BMjE3MDU2NzQyMl5BMl5BanBnXkFtZTgwMzQxMDQ3NTE@._V1_SX300.jpg\",\"Title\":\"Maze Runner: The Scorch Trials\",\"Type\":\"movie\",\"Year\":2015,\"imdbID\":\"tt4046784\"},{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BMjExOTkxMTIzN15BMl5BanBnXkFtZTgwNjcxNzY2NTE@._V1_SX300.jpg\",\"Title\":\"Into the Grizzly Maze\",\"Type\":\"movie\",\"Year\":2015,\"imdbID\":\"tt1694021\"},{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BMTIwNDg4MjIyMV5BMl5BanBnXkFtZTcwNDEwMzkxMQ@@._V1_SX300.jpg\",\"Title\":\"Hercules in the Maze of the Minotaur\",\"Type\":\"movie\",\"Year\":1994,\"imdbID\":\"tt0110018\"},{\"Poster\":\"http://ia.media-imdb.com/images/M/MV5BNTRkNzI4YTktNTBmMi00OWNlLWExODctMTA0ODdiNDNjZTkzXkEyXkFqcGdeQXVyMTk3MTY0NDc@._V1_SX300.jpg\",\"Title\":\"The Crystal Maze\",\"Type\":\"series\",\"Year\":1990,\"imdbID\":\"tt0098774\"},{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BMTk0MTAxODI3N15BMl5BanBnXkFtZTcwMjI1NTk5Mw@@._V1_SX300.jpg\",\"Title\":\"The Maze\",\"Type\":\"movie\",\"Year\":2010,\"imdbID\":\"tt1675758\"},{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BMTkwNzE5MTA1NF5BMl5BanBnXkFtZTcwODQ3NzkxMQ@@._V1_SX300.jpg\",\"Title\":\"Maze\",\"Type\":\"movie\",\"Year\":2000,\"imdbID\":\"tt0246072\"},{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BNDY4NDAxNjgzOF5BMl5BanBnXkFtZTcwNDEyMjAzMQ@@._V1_SX300.jpg\",\"Title\":\"Iron Maze\",\"Type\":\"movie\",\"Year\":1991,\"imdbID\":\"tt0102128\"},{\"Poster\":\"https://images-na.ssl-images-amazon.com/images/M/MV5BMTg2Mjk1MDE3OF5BMl5BanBnXkFtZTcwOTk2OTYxMg@@._V1_SX300.jpg\",\"Title\":\"The Maze\",\"Type\":\"movie\",\"Year\":1953,\"imdbID\":\"tt0046057\"},{\"Poster\":\"http://ia.media-imdb.com/images/M/MV5BNmI4YWUyNzctYjcyYy00OTdkLTljOTgtOGQxNDJhNjNhODZkXkEyXkFqcGdeQXVyNTUzNzE0ODE@._V1_SX300.jpg\",\"Title\":\"Maze Runner: The Burn Trials\",\"Type\":\"movie\",\"Year\":2015,\"imdbID\":\"tt4844320\"}]}")]
        public void MockingObjet_GetTotalMovies_Return_QtdMovies(string titleMovie, int expected, string dataHardCode)
        {
            //I am Violating the DRY principle Here ALL the Time
            //Don’t-Repeat-Yourself (DRY) design principle

            //Arrange
            //Create in Memory Fake Object and Use this isolate object
            //In a Mock Obj, I wanna tell it What I want to do,  when I expected to do when I call a particular Method
            var serviceMock = new Mock<IGetServices>();
            serviceMock.Setup(s => s.GetServiceQtdMovies(It.IsAny<string>())).Returns(dataHardCode);

            //Action
            var calculator = new Calculator();

            //This Is the Magic tha Mock Do
            calculator.Service = serviceMock.Object;

            var result = calculator.GetMoviesTotal(titleMovie);

            //Assert
            Assert.AreEqual(expected, result);

        }


        [Test]
        [TestCase("maze",97)]
        [TestCase("Waterworld", 11)]
        
        public void IntegrationTest_GetTotalMovies_Return_QtdMovies(string titleMovie, int expected)
        {
            //I am Violating the DRY principle Here ALL the Time
            //Don’t-Repeat-Yourself (DRY) design principle

            //Arrange
            var calculator = new Calculator();

            //Action
            var result = calculator.GetMoviesTotal(titleMovie);

            //Assert
            Assert.AreEqual(expected, result);

        }

    }
}
