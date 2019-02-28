////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   init.cs                                  //
//              One function calls other initialization functions             //
//             Created by: Jarett (Jay) Mirecki, February 26, 2019            //
//            Modified by: Jarett (Jay) Mirecki, February 27, 2019            //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS {
    partial class GSWS {
        // Init()
        // Initializes everything needed to start the program
        // Parameters: None
        // Returns: void
        public static void Init() {
            Initialize.Menus.Init();
        }
    }
}