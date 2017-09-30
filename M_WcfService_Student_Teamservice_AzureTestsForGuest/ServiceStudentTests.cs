using Microsoft.VisualStudio.TestTools.UnitTesting;
using M_WcfService_Student_Teamservice_Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_WcfService_Student_Teamservice_Azure.Tests
{
    [TestClass()]
    public class ServiceStudentTests
    {
        [TestMethod()]
        [TestCategory("Guest")]
        [TestProperty("Ny guest gruppe", "Tomt navn")]
        [Owner("Rolf")]
        [Priority(1)]
        [ExpectedException(typeof(FejliAddGuest))]
        public void AddGuestTest()
        {
            // Arrange
            var guest = new Guest(41, "", "Pilevej 14");
            //Act
            string tomtnavn = guest.Name;
            //Asser
            Assert.AreEqual("", tomtnavn);
        }

        [TestMethod()]
        [TestCategory("Guest")]
        [TestProperty("Ny guest gruppe", "Tom adresse")]
        [Owner("Rolf")]
        [Priority(1)]
        [ExpectedException(typeof(FejlIAdresse))]
        public void GuestAdresseTest()
        {
            var guest2 = new Guest(42,"Ib","");

            string tomAdresse = guest2.Address;

            Assert.AreEqual("", tomAdresse);
        }

       
    }
}