using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using GSWS;

public class LoadSceneOnClick : MonoBehaviour
{
    public InputField playername;
    public Dropdown era;
    public Dropdown faction;
    public GameObject Object;
    private enum Scenes { MainMenu, Game, Map };
    // public Game game;
    public void LoadByIndex(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
    public void LoadGame() {
        string time = "";
        string factions;
        if (era.value == 0)
            time = "183 ABY";
        if (faction.value == 0)
            factions = "New Republic";
        else
            factions = "Galactic Empire";
        Game.SetInstance(playername.text, factions, 1000, time);
        SceneManager.LoadScene((int)Scenes.Game);
        Game.InitCampaign("PostEndor");
    }
    public void LoadMap() {
        SceneManager.LoadScene((int)Scenes.Map);
    }
    public void LoadMainMenu() {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }
}
