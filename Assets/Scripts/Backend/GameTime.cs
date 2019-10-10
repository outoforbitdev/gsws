using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using GSWS;

public partial class Game : MonoBehaviour
{
    public void StartTime() {
        InvokeRepeating("AdvanceTime", 1f, 1f);
    }
    public void StopTime() {
        CancelInvoke("AdvanceTime");
    }
    public void AdvanceTime() {
        Game.DB.AdvanceTime();
    }
    public void AdvanceDay() {
        // Date.DateInt++;

    }
    public void AdvanceWeek() {

    }
    public void AdvanceMonth() {
        // float residentialValue, commercialValue, totalRevenue;
        // foreach (Government aGovernment in new List<Government>(Governments.Values)) {
        //     residentialValue = commercialValue = totalRevenue = 0f;
        //     foreach (string planetName in aGovernment.MemberPlanets) {
        //         residentialValue += Game.DB.GetPlanet(planetName).ResidentialValue();
        //         commercialValue += Game.DB.GetPlanet(planetName).IndustrialValue();
        //     }
        //     totalRevenue = 
        //         residentialValue * aGovernment.ResidentialTax + commercialValue * aGovernment.CommercialTax;
        //     totalRevenue = totalRevenue / (368f/12f);
        //     aGovernment.Budget.Balance += 
        //         aGovernment.Budget.GetSurplus() * totalRevenue;
        // }
    }
    public void AdvanceYear() {

    }
}