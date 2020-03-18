using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GSWS;

public class GovernmentController : MonoBehaviour
{
    public Text GovernmentName, ResidentialTaxRate, CommercialTaxRate, AnnualRevenue;
    public Slider ResidentialSlider, CommercialSlider;
    private float ResidentialValue, CommercialValue;
    // Start is called before the first frame update
    void Start()
    {
        Government playerGovernment = Game.DB.Player.Faction;
        GovernmentName.text = playerGovernment.Name;
        ResidentialTaxRate.text = (playerGovernment.ResidentialTax * 100f).ToString("#0.0");
        CommercialTaxRate.text = (playerGovernment.CommercialTax * 100f).ToString("#0.0");
        ResidentialSlider.value = playerGovernment.ResidentialTax;
        CommercialSlider.value = playerGovernment.CommercialTax;
        ResidentialValue = CommercialValue = 0;
        foreach (Planet p in playerGovernment.MemberPlanets) {
            ResidentialValue += p.ResidentialValue();
            // CommercialValue += p.IndustrialValue();
        }
        AnnualRevenue.text = (ResidentialValue * playerGovernment.ResidentialTax + CommercialValue * playerGovernment.CommercialTax).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Government playerGovernment = Game.DB.Player.Faction;
        playerGovernment.ResidentialTax = ResidentialSlider.value;
        playerGovernment.CommercialTax = CommercialSlider.value;
        ResidentialTaxRate.text = (playerGovernment.ResidentialTax * 100f).ToString("#0.0");
        CommercialTaxRate.text = (playerGovernment.CommercialTax * 100f).ToString("#0.0");
        AnnualRevenue.text = Game.CreditString(ResidentialValue * playerGovernment.ResidentialTax + CommercialValue * playerGovernment.CommercialTax);
    }
}
