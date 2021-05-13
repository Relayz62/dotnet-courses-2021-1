using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace PLL.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public List<Awards> Awards { get; set; }
        public List<AwardViewModel> AvailableAwards { get; set; }

        public User ToUser()
        {
            return new User(FirstName, LastName, Birthdate)
            {
                ID = ID,
                AwardsList = AvailableAwards
                    .Where(r => r.Checked == true)
                    .Select(r => new Awards(r.Title, r.Description)
                    {
                        ID = r.ID
                    }).ToList()
            };
        }
        public static UserViewModel GetViewModel(User user, List<Awards> availableRewards)
        {
            var userModel = new UserViewModel
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                Awards = user.AwardsList
            };
            var awards = new List<AwardViewModel>();
            foreach (var award in availableRewards)
            {
                awards.Add(AwardViewModel.GetViewModel(award, user.AwardsList));
            }

            userModel.AvailableAwards = awards.ToList();
            return userModel;
        }
    }
}
