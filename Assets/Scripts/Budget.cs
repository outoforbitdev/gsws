////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                 Budget.cs                                  //
//                                Budget class                                //
//             Created by: Jarett (Jay) Mirecki, August 08, 2019              //
//             Modified by: Jarett (Jay) Mirecki, August 08, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[Serializable] public class Budget {
    public float Military, PublicSafety, Health, Education, Balance;

    private void InitInstance() {
        Military = PublicSafety = Health = Education = Balance = 0;
    }
    public Budget() {
        InitInstance();
    }
    public void SetMilitary(float value) {
        if (GetSurplus() >= (value - Military))
            Military = value;
        else
            Military = GetSurplus();
    }
    public void SetPublicSafety(float value) {
        if (GetSurplus() >= (value - PublicSafety))
            PublicSafety = value;
        else
            PublicSafety = GetSurplus();
    }
    public void SetHealth(float value) {
        if (GetSurplus() >= (value - Health))
            Health = value;
        else
            Health = GetSurplus();
    }
    public float GetSurplus() {
        return 1 - (Military + PublicSafety + Health + Education);
    }
}