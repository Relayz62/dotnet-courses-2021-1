using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Department.DAL
{
    public interface IAwardDAO
    {
        void AddAward(Awards award);
        void EditAward(int index, Awards newAward);
        void RemoveAward(int awardID);
        IEnumerable<Awards> GetAwardList();
        Awards GetCurrentAward(int index);
        IEnumerable<Awards> SortAwardByASC(Func<Awards, object>[] sortDelegate, int index);
        IEnumerable<Awards> SortAwardByDESC(Func<Awards, object>[] sortDelegate, int index);
    }
}
