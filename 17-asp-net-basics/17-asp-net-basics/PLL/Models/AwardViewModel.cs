using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace PLL.Models
{
    public class AwardViewModel
    {
		public int ID { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }

		public bool Checked { get; set; }

		public static AwardViewModel GetViewModel(Awards award, List<Awards> userAwards)
		{
            var model = new AwardViewModel
            {
                ID = award.ID,
                Title = award.Title,
                Description = award.Description,
                Checked = userAwards.Any(r => r.ID == award.ID)
            };
            return model;
		}
	}
}
