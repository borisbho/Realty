using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesLib.Model
{
    public class HomesListModel
    {
        public List<HomesModel> Homes { get; set; }

        public HomesListModel()
        {
            Homes = new List<HomesModel>();
        }
    }
}
