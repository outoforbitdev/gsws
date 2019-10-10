using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GSWS;

public class LoadSceneOnClick : MonoBehaviour
{
    public InputField playername;
    public Dropdown era;
    public Dropdown faction;
    public CampaignController campaignControl;
    public GameObject Object;
    private enum Scenes { MainMenu, Game, Map };
    // public Game game;
    public void LoadByIndex(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
    public void LoadGame() {
        string campaign;
        string factions;
        Date date;

        campaign = campaignControl.CampaignList.ToArray()[era.value].ID;
        factions = campaignControl.CampaignList.ToArray()[era.value].FactionIDs.ToArray()[faction.value];
        date = campaignControl.CampaignList.ToArray()[era.value].Date;

        Game.SetInstance(playername.text, factions, 1000, date.ToString());
        Game.InitCampaign(campaign, factions, date);
        SceneManager.LoadScene((int)Scenes.Game);
    }
    public void LoadMap() {
        SceneManager.LoadScene((int)Scenes.Map);
    }
    public void LoadMainMenu() {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }
}
