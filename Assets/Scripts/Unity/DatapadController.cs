using System.Collections;
using System.Collections.Generic;
using GSWS;
using UnityEngine;
using UnityEngine.UI;


public class DatapadController : MonoBehaviour
{
    public Toggle Fleets, Planets;
    public GameObject DatapadResultsView, DatapadResult;
    public Text DatapadInformation;
    private bool FleetsValue, PlanetsValue;
    void Start() {
        Fleets.isOn = Planets.isOn = false;
        FleetsValue = PlanetsValue = false;
        ReloadResults();
        Fleets.onValueChanged.AddListener(delegate { ReloadResults(); });
        Planets.onValueChanged.AddListener(delegate { ReloadResults(); });
    }
    void Update() {
        if (Fleets.isOn != FleetsValue ||
            Planets.isOn != PlanetsValue) {
            FleetsValue = Fleets.isOn;
            PlanetsValue = Planets.isOn;
            // ReloadResults();
        }
    }
    private void ReloadResults() {
        Debug.Log("results");
        foreach (Transform child in DatapadResultsView.transform) {
            Debug.Log(child.name);
            Object.Destroy(child.gameObject);
        }
        // DatapadResultsView.
        if (Planets.isOn) LoadPlanets();
    }
    private void LoadPlanets() {
        if (!Planets.isOn) {
            return;
        }

        foreach (Planet planet in Game.DB.GetPlanets().Values()) {
            var result = 
                Instantiate(DatapadResult, DatapadResultsView.transform);
            // Debug.Log(result.ToString());
            result.name = planet.ID;
            result.GetComponent<Button>().onClick.AddListener(delegate { DatapadInformation.text = planet.Name; });
            var comp = result.GetComponentInChildren<Text>().text = planet.Name;
        }
    }
}