using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    abstract public class Item
    {
        private string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == null)
                {
                    _id = value;
                }
            }
        }
        public abstract Item Clone();
    }
}
