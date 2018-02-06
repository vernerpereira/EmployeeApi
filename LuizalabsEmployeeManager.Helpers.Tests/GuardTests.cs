using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LuizalabsEmployeeManager.Helpers.Tests
{
    [TestClass]
    public class GuardTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmpty_Em_Branco()
        {
            Guard.ForNullOrEmpty("", "the value can't be empty");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmpty_Null()
        {
            Guard.ForNullOrEmpty(null, "the value can't be null");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmptyDefaultMessage_Em_Branco()
        {
            Guard.ForNullOrEmptyDefaultMessage("", "Field");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmptyDefaultMessage_Null()
        {
            Guard.ForNullOrEmptyDefaultMessage(null, "Field");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLength_Max_1()
        {
            Guard.StringLength("12345", 2, "It is not allowed more than 2 characters");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLength_Max_2()
        {
            Guard.StringLength("Field", "12345", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLength_Min_Max_Testando_Min_1()
        {
            Guard.StringLength("12345", 7, 10, "The characters quantity needs to be between 7 and 10 characters.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLength_Min_Max_Testando_Max_1()
        {
            Guard.StringLength("12345123456", 7, 10, "The characters quantity needs to be between 7 and 10 characters.");
        }
    }
}
