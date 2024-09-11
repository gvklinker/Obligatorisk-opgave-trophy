using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorisk_opgave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        private Trophy t1;
        private Trophy t2;
        private Trophy t3;
        private Trophy t4;
        private Trophy t5;
        private Trophy t6;
        private void Setup()
        {
            t1 = new Trophy() { Competition = "Karate", Year = 1970 };
            t2 = new Trophy() { Competition = "Ki", Year = 2011 };
            t3 = new Trophy() { Competition = "Judo", Year = 2025 };
            t4 = new Trophy() { Competition = "Chi", Year = 2024 };
            t5 = new Trophy() { Competition = "Kung-Fu", Year = 1969 };
            t6 = new Trophy() { Year = 2000};
        }
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void ValidateTest()
        {
            Setup();
            t1.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>t2.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => t3.Validate());
            t4.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => t5.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => t6.Validate());
        }
    }
}