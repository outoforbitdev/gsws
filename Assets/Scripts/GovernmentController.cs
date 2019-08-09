using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GovernmentController : MonoBehaviour
{
    public Text GovernmentName, ResidentialTaxRate, CommercialTaxRate, AnnualRevenue;
    public Slider ResidentialSlider, CommercialSlider;
    private float ResidentialValue, CommercialValue;
    // Start is called before the first frame update
    void Start()
    {
        Government playerGovernment = Game.GetPlayerGovernment();
        GovernmentName.text = playerGovernment.Name;
        ResidentialTaxRate.text = (playerGovernment.ResidentialTax * 100f).ToString("#0.0");
        CommercialTaxRate.text = (playerGovernment.CommercialTax * 100f).ToString("#0.0");
        ResidentialSlider.value = playerGovernment.ResidentialTax;
        CommercialSlider.value = playerGovernment.CommercialTax;
        ResidentialValue = CommercialValue = 0;
        foreach (string planetName in playerGovernment.MemberPlanets) {
            ResidentialValue += Game.GetPlanetFromString(planetName).ResidentialValue();
            CommercialValue += Game.GetPlanetFromString(planetName).IndustrialValue();
        }
        AnnualRevenue.text = (ResidentialValue * playerGovernment.ResidentialTax + CommercialValue * playerGovernment.CommercialTax).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Government playerGovernment = Game.GetPlayerGovernment();
        playerGovernment.ResidentialTax = ResidentialSlider.value;
        playerGovernment.CommercialTax = CommercialSlider.value;
        ResidentialTaxRate.text = (playerGovernment.ResidentialTax * 100f).ToString("#0.0");
        CommercialTaxRate.text = (playerGovernment.CommercialTax * 100f).ToString("#0.0");
        AnnualRevenue.text = Game.CreditString(ResidentialValue * playerGovernment.ResidentialTax + CommercialValue * playerGovernment.CommercialTax);
    }
}
