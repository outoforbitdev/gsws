using System;
using System.Collections.Generic;
using System.Text;
using GSWS.Assets.Database;

namespace GSWS.Assets.Tests.Database
{
    class ReadTestItem: ReadItem<TestItem>
    {
        public ReadTestItem(): base()
        {

        }
        public ReadTestItem(TestItem original) : base(original)
        {

        }
    }
}
