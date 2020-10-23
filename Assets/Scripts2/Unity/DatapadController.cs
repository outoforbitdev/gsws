using System.Collections;
using System.Collections.Generic;
using GSWS;
using UnityEngine;
using UnityEngine.UI;


public class DatapadController : MonoBehaviour
{
    public Toggle Fleets, Planets, Factions, Governments, Militaries;
    public InputField SearchTerm;
    public GameObject DatapadResultsView, DatapadResult, InformationButtons;
    public Text DatapadInformation;
    public Button DatapadViewMap;

    void Start() {
        ClearInformationButtons();
        Fleets.isOn = Planets.isOn = Governments.isOn = Factions.isOn = Militaries.isOn = false;
        ReloadResults();
        Fleets.onValueChanged.AddListener(delegate { ReloadResults(); });
        Planets.onValueChanged.AddListener(delegate { ReloadResults(); });
        Governments.onValueChanged.AddListener(delegate { ReloadResults(); });
        Factions.onValueChanged.AddListener(delegate { ReloadResults(); });
        Militaries.onValueChanged.AddListener(delegate { ReloadResults(); });
        SearchTerm.onValueChanged.AddListener(delegate { ReloadResults(); });
    }
    void Update() {

    }
    private void ReloadResults() {
        foreach (Transform child in DatapadResultsView.transform) {
            Object.Destroy(child.gameObject);
        }
        if (SearchTerm.text.Length >= 3) LoadResults();
    }
    private void ClearInformationButtons() {
        foreach (Transform child in InformationButtons.transform) {
            Object.Destroy(child.gameObject);
        }
    }
    private void LoadResults() {
        List<KeyValuePair<string, System.Type>> results = Game.DB.Search(SearchTerm.text, false, Factions.isOn, Fleets.isOn, Governments.isOn, Militaries.isOn, Planets.isOn);
        foreach(KeyValuePair<string, System.Type> r in results) {
            var resultDisplay = 
                Instantiate(DatapadResult, DatapadResultsView.transform);
            resultDisplay.GetComponent<Button>().onClick.AddListener(ClearInformationButtons);
            if (r.Value == new Fleet().GetType())
                GenerateFleetInfo(resultDisplay, r.Key);
            else if (r.Value == new Planet().GetType())
                GeneratePlanetInfo(resultDisplay, r.Key);
            else if (r.Value == new Government().GetType())
                GenerateGovernmentInfo(resultDisplay, r.Key);
            else if (r.Value == new Military().GetType())
                GenerateMilitaryInfo(resultDisplay, r.Key);
        }
    }
    private void GenerateFleetInfo(GameObject resultDisplay, string key) {
        Fleet fleet = Game.DB.Fleets[key];
        resultDisplay.name = fleet.ID;
        resultDisplay.GetComponent<Button>().onClick.AddListener(delegate { 
            if (fleet.Orbiting != null)
                InstantiateMapButton(fleet.Orbiting.Position);
            DatapadInformation.text = fleet.DatapadDescription(); });
        resultDisplay.GetComponentInChildren<Text>().text = fleet.Name;
    }
    private void GeneratePlanetInfo(GameObject resultDisplay, string key) {
        Planet planet = Game.DB.Planets[key];
        resultDisplay.name = planet.ID;
        resultDisplay.GetComponent<Button>().onClick.AddListener(delegate { 
            InstantiateMapButton(planet.Position);
            DatapadInformation.text = planet.DatapadDescription(); });
        resultDisplay.GetComponentInChildren<Text>().text = planet.Name;
    }
    private void GenerateGovernmentInfo(GameObject resultDisplay, string key) {
        Government government = Game.DB.Governments[key];
        resultDisplay.name = government.ID;
        resultDisplay.GetComponent<Button>().onClick.AddListener(delegate { 
            DatapadInformation.text = government.DatapadDescription(); });
        resultDisplay.GetComponentInChildren<Text>().text = government.Name;
    }
    private void GenerateMilitaryInfo(GameObject resultDisplay, string key) {
        Military military = Game.DB.Militaries[key];
        resultDisplay.name = military.ID;
        resultDisplay.GetComponent<Button>().onClick.AddListener(delegate { 
            DatapadInformation.text = military.DatapadDescription(); });
        resultDisplay.GetComponentInChildren<Text>().text = military.Name;
    }
    private void InstantiateMapButton(Coordinate position) {
        var mapButton = 
            Instantiate(DatapadViewMap, InformationButtons.transform);
        mapButton.onClick.AddListener(delegate {
            Game.MapCameraLocation = Map.AsMapVector(position);
        });
    } 
}