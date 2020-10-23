////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                 IObject.cs                                 //
//                             IObject Interface                              //
//                  Created by: Jay Mirecki, March 17, 2020                   //
//                  Modified by: Jay Mirecki, March 17, 2020                  //
//                                                                            //
//          The IObject interface is everything that each object              //
//          should implement, such as the ability to verify the               //
//          integrity of objects and keys.                                    //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace GSWS.Assets.Server
{
    [Serializable]
    abstract public class Object
    {
        private string _id;
        [XmlAttribute]
        public string ID { 
            get
            {
                return _id;
            } 
            set
            {
                if (string.IsNullOrWhiteSpace(ID))
                {
                    _id = value;
                }
            }
        }
        abstract public override string ToString();
        abstract public string DatapadDescription();
        abstract public void UpdateValues(Database db);
        abstract public void UpdateKeys();
        abstract public void VerifySubGroups();
        abstract public void UpdateSuperGroups();
    }
}