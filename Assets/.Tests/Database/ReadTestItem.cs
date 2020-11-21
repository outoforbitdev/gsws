using System;
using System.Collections.Generic;
using System.Text;
using GSWS.Assets.Database;

namespace GSWS.Assets.Tests.Database
{
    class ReadTestItem: ReadItem<TestItem>
    {
        public string ID
        {
            get { return Original.ID;  }
        }
        public int Field
        {
            get { return Original.Field; }
        }
        public ReadTestItem(): base()
        {

        }
        public ReadTestItem(TestItem original) : base(original)
        {

        }
    }
}
