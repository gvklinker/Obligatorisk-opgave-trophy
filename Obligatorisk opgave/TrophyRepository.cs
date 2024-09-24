using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave
{
    public class TrophyRepository
    {
        private List<Trophy> repo;
        public int Count { get { return repo.Count; } }
        public TrophyRepository()
        {
            repo = new List<Trophy>();
        }
        public List<Trophy> Get(int? minYear = null, int? maxYear = null, string? sort = null) { 
            List<Trophy> list = new List<Trophy>(repo); 
            if (minYear != null)
                list = list.FindAll(x => x.Year >= minYear);
            if (maxYear != null)
                list = list.FindAll(x => x.Year <= maxYear);
            if (sort != null)
            {
                switch (sort.ToLower())
                {
                    case "year": list.OrderBy(x => x.Year); break;
                    case "competition": list.OrderBy(x => x.Competition); break;
                    default: break;
                }
            }
            return list;
        }

        public Trophy GetById(int id)
        {
            return repo.Find(x => x.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            trophy.Id = Count > 0 ? ++repo.LastOrDefault().Id : 1;
            repo.Add(trophy);
            return GetById(trophy.Id);
        }
        public Trophy Remove(int id) {
            repo.Remove(GetById(id));
            return GetById(id);
        }
        public Trophy Update(int id, Trophy trophy) {
            Trophy trophyUpdate = GetById(id);
            trophyUpdate.Competition = trophy.Competition;
            trophyUpdate.Year = trophy.Year;
            return GetById(id);
        }
    }
}
