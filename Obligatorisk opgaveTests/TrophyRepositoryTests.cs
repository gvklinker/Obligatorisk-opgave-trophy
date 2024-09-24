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
    public class TrophyRepositoryTests
    {
        private TrophyRepository _repository;
        private void Setup()
        {
            _repository = new TrophyRepository();
            _repository.Add(new Trophy { Year = 1989, Competition = "Basket ball" });
            _repository.Add(new Trophy { Year = 2001, Competition = "Karate" });
            _repository.Add(new Trophy { Year = 2013, Competition = "Squash" });
            _repository.Add(new Trophy { Year = 2024, Competition = "Hockey" });
        }

        [TestMethod()]
        public void GetTest()
        {
            Setup();
            Assert.AreEqual(_repository.GetById(3), _repository.Get(minYear: 2010).FirstOrDefault());
            Assert.AreEqual(_repository.GetById(2), _repository.Get(maxYear: 2010).LastOrDefault());
            Assert.AreEqual(_repository.GetById(3), _repository.Get(sort: "competition").LastOrDefault());
        }


        [TestMethod()]
        public void RemoveTest()
        {
            Setup();
            _repository.Remove(2);
            Assert.AreEqual(3, _repository.Count);
            Assert.AreEqual(null, _repository.GetById(2));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Setup();
            _repository.Update(4, new Trophy {Year = 2024, Competition = "Ice Hockey" });
            Assert.AreEqual(new Trophy { Id = 4, Year = 2024, Competition = "Ice Hockey" }, _repository.GetById(4));
        }
    }
}