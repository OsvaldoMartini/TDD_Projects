using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expected_Classes;
using Expected_Interfaces;
using NUnit.Framework;

namespace TDD_Case_1
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
    public class ServiceSunsetCalculatorTests
    {

       string goodData =  "{\"result\":{\"sunrise\":\"6:37:49 AM\",\"sunset\":\"4:42:49 PM\",\"solar_noon\":\"11:40:19 AM\",\"day_length\":\"10:05:00.1530000\"},\"status\":\"OK\"}";
       string badData = "{\"results\":null,\"status\":\"ERROR\"}";
                       
        [Test]
        public void ServiceSunsetCalculator_ImplementsISunsetCalculator()
        {
            //Arrange values to Initiate de TDD
            var srvSunsetCalculator = new ServiceSunsetCalculator();
            
            //Actions and/or Methods

            //Assert
            Assert.IsInstanceOf<IServiceSunsetCalculator>(srvSunsetCalculator);
        }

        [Test]
        public void ParseJSonSunsetValue_OnGoodData_ReturnExpectedString()
        {
            //Arrange values  - Expected
            string expected = "4:42:49 PM";
            //Action
            string result = ServiceSunsetCalculator.ParseSunset(goodData);
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
                string result = ServiceSunsetCalculator.ParseSunset(badData);
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
            DateTime result = ServiceSunsetCalculator.ToLocalTime(timeString, date);

            //Assert
            Assert.AreEqual(expected, result);

        }
    }
}
