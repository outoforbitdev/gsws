using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    public abstract class ReadItem<T>
        where T : Item
    {
        private T Original;
        public ReadItem()
        {

        }
        public ReadItem(T original)
        {
            Original = original;
        }
        public void SetOriginal(T original)
        {
            if (Original == null)
            {
                Original = original;
            }
        }
    }
}
