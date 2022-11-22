using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopApp.Model
{
    public partial class BouquetFlower
    {
        public double TotalCost
        {
            get
            {
                return Flower.Cost * Quantity;
            }
            set
            {

            }
        }
    }
}
