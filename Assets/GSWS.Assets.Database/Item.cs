using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    abstract public class Item
    {
        public string ID;

        abstract public Item Clone();
    }
}
