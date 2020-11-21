using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWS.Assets.Database
{
    public class EditItem<T>
        where T : Item
    {
        private T _original;
        public T Original
        {
            set { 
                if (_original == null)
                    {
                        _original = value;
                    }
            }
            get { return _original; }
        }
        private Lock _lock;
        internal Lock Lock
        {
            set
            {
                if (_lock == null)
                {
                    _lock = value;
                }
            }
        }
        public EditItem()
        {

        }
        public EditItem(T original)
        {
            Original = original;
        }

    }
}
