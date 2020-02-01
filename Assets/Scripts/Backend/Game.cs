using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using GSWS;

public partial class Game : MonoBehaviour
{
    public static Game Instance;
    public static Database DB;
    public static Vector3 MapCameraLocation;

    void Awake () {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Destroy (gameObject);
        }
    }
    public static void SetInstance(string playerName, string factionName, int funds, string date) {
        DB = new Database(new Player(playerName, factionName), 
                          new Date(1840, DateSystem.ABY));
        MapCameraLocation = new Vector3(0f, 0f, 0f);
    }
    public static void InitCampaign(string campaignName, string factionID, Date date) {
        string directory = 
            Application.persistentDataPath + "/Data/Campaigns/" + campaignName + "/";
        Debug.Log(directory);
        Debug.Log(Directory.GetCurrentDirectory());
        DB.LoadDatabase(directory, DB.GetPlayer());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static string CreditString(float value) {
        string valueString;
        if (value > 1000000000000000000000000000f)
            valueString =
                value.ToString("###,###,###,###,###,,,,,,,,,.00") + " octillion";
        else if (value > 1000000000000000000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,,,,,,.00") + " septillion";
        else if (value > 1000000000000000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,,,,,.00") + " sextillion";
        else if (value > 1000000000000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,,,,.00") + " quintillion";
        else if (value > 1000000000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,,,.00") + " quadrillion";
        else if (value > 1000000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,,.00") + " trillion";
        else if (value > 1000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,.00") + " billion";
        else if (value > 1000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,.00") + " million";
        else
            valueString = 
                value.ToString("###,##0");
        return valueString + " credits";
    }
}
