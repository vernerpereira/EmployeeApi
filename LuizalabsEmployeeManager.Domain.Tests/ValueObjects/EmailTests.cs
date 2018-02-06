using LuizalabsEmployeeManager.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LuizalabsEmployeeManager.Domain.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_Empty()
        {
            var email = new Email("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_Null()
        {
            var email = new Email(null);
        }

        [TestMethod]
        public void Email_Valid()
        {
            var endereco = "vernerpereira@gmail.com";
            var email = new Email(endereco);
            Assert.AreEqual(endereco, email.Address);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_Invalid()
        {
            var email = new Email("asdfasdfasdf");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_MaxLength()
        {
            var endereco = "vernerpereira@gmail.com";
            while (endereco.Length < Email.AddressMaxLength + 1)
            {
                endereco = endereco + "123";
            }
            new Email(endereco);
        }
    }
}
