using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.DAL
{
    public class AwardsDAO : IAwardDAO
    {

        private List<Awards> _awards = new List<Awards>();
        public void AddAward(Awards award)
        {
            if (award == null)
                throw new ArgumentNullException("Award");

            _awards.Add(award);
        }

        public void EditAward(int index, Awards newAward)
        {
            _awards[index] = newAward;
        }

        public IEnumerable<Awards> GetAwardList()
        {
            return _awards;
        }

        public Awards GetCurrentAward(int ID)
        {
            return _awards.FirstOrDefault(u => u.ID == ID);
        }

        public void RemoveAward(Awards award)
        {
            _awards.Remove(award);
        }

        public IEnumerable<Awards> SortAwardByASC(Func<Awards, object>[] sortDelegate, int index)
        {
            return _awards = _awards.OrderBy(sortDelegate[index]).ToList();
        }

        public IEnumerable<Awards> SortAwardByDESC(Func<Awards, object>[] sortDelegate, int index)
        {
            return _awards = _awards.OrderByDescending(sortDelegate[index]).ToList();
        }
    }
}
