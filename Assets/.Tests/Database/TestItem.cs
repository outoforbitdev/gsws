using System;
using System.Collections.Generic;
using System.Text;
using GSWS.Assets.Database;

namespace GSWS.Assets.Tests.Database
{
    public class TestItem: Item
    {
        public int Field;
        public TestItem() { }
        public TestItem(string id, int field)
        {
            Field = field;
            ID = id;
        }
        public override Item Clone()
        {
            return new TestItem(ID, Field);
        }
    }
}
