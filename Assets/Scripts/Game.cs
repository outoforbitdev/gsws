using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSWS;
using JMSuite.Collections;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public Faction Faction;
    private Date Date;
    public Player Player;
    public Graph<string, Planet> Planets;
    public Dictionary<string, Faction> Factions;
    public Vector3 MapCameraLocation;

    void Awake () {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Destroy (gameObject);
        }
    }
    public static void SetInstance(string playerName, string factionName, int funds, string date) {
        Instance.Player = new Player(playerName);
        Instance.Faction = new Faction(factionName);
        Instance.Date = new Date(1840, DateSystem.ABY);
        Instance.Planets = new Graph<string, Planet>();
        Instance.MapCameraLocation = new Vector3(0f, 0f, 0f);
    }
    public static string DateToString() {
        return Instance.Date.ToString();
    }
    public static void InitCampaign(string campaignName) {
        string directory = 
            Application.persistentDataPath + "/Data/Campaigns/" + campaignName + "/";
        Debug.Log(directory);
        Instance.LoadPlanets(directory);
        Instance.LoadFactions(directory);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadPlanets(string directory) {
        List<Planet> planetList = new List<Planet>();
        Serializer<List<Planet>> PlanetListSerializer = 
            new Serializer<List<Planet>>();
        planetList = 
            PlanetListSerializer.Deserialize(directory + "planets.xml");
        foreach(Planet aPlanet in planetList) 
            Planets.Add(aPlanet.ID, aPlanet, aPlanet.Neighbors);
    }
    private void LoadFactions(string directory) {
        Faction empire = new Faction("Galactic Empire");
        Faction rebels = new Faction("New Republic");
        empire.ID = "empire";
        empire.AddRelationship(rebels.ID, 0);
        empire.Color = "Red";
        rebels.ID = "newrepublic";
        rebels.AddRelationship(empire.ID, 0);
        rebels.Color = "Blue";

        List<Faction> factionList = new List<Faction>();
        factionList.Add(empire);
        factionList.Add(rebels);

        Factions = new Dictionary<string, Faction>();
        foreach(Faction aFaction in factionList)
            Factions.Add(aFaction.ID, aFaction);
        foreach(Planet aPlanet in Planets.Values()) {
            Faction pFaction;
            if (Factions.TryGetValue(aPlanet.Faction, out pFaction)) {
                if (!pFaction.Planets.Contains(aPlanet.ID))
                    pFaction.Planets.Add(aPlanet.ID);
            }
        }
    }
    public Faction GetFactionFromString(string faction) {
        Faction Faction;
        if (Factions.TryGetValue(faction, out Faction))
            return Faction;
        else
            throw new KeyNotFoundException();
    }
}
