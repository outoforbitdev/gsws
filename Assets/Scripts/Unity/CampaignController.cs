using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampaignController : MonoBehaviour
{
    public List<Campaign> CampaignList;
    public Dropdown Campaigns;
    public Dropdown Factions;
    // Start is called before the first frame update
    void Start() {
        CampaignList = new Serializer<List<Campaign>>().Deserialize(Application.persistentDataPath + "/Data/Campaigns/campaignList.xml");

        Campaigns.ClearOptions();
        foreach (Campaign aCampaign in CampaignList) {
            Dropdown.OptionData currCampaign = new Dropdown.OptionData();
            currCampaign.text = aCampaign.Name;
            Campaigns.options.Add(currCampaign);
        }
        Campaigns.value = 0;
        Campaigns.RefreshShownValue();
        Campaigns.onValueChanged.AddListener((value) => UpdateFactions(value));
        UpdateFactions(0);
    }
    public void UpdateFactions(int index) {
        Factions.ClearOptions();
        foreach (string Faction in CampaignList.ToArray()[index].FactionNames) {
            Dropdown.OptionData currFaction = new Dropdown.OptionData();
            currFaction.text = Faction;
            Factions.options.Add(currFaction);
        }
        Factions.value = 0;
        Factions.RefreshShownValue();
    }
}