using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database.Items
{
    public class Ship: Item
    {
        public override Item Clone()
        {
            Ship copy = new Ship();
            return copy;
        }
    }
}
