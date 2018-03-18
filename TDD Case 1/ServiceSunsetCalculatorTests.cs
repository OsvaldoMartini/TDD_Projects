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
        public void ParseJSonSunsetValu_OnGoodData_ReturnExpectedString()
        {
            //Arrange values  - Expected
            string expected = "4:42:49 PM";
            //Action
            string result = ServiceSunsetCalculator.ParseSunset(goodData);
            //Assert
            Assert.AreEqual(expected,result);
        }
    }
}
