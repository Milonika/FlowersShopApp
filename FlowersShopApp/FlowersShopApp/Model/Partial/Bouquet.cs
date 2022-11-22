using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopApp.Model
{
    public partial class Bouquet
    {
        public int TotalFlowersQuantity
        {
            get
            {
                List<Model.BouquetFlower> bouquetFlowers = MainWindow.db.BouquetFlower.Where(c => c.BouquetId == Id).ToList();
                int total = 0;
                foreach(var c in bouquetFlowers)
                {
                    total += c.Quantity;
                }
                return total;
            }
            set
            {


            }
        }
    }
}
