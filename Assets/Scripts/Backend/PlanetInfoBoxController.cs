using UnityEngine;
using UnityEngine.UI;
using GSWS;

public class PlanetInfoBoxController : MonoBehaviour
{
    public Text Name, Location, Physical, Faction, Population, Value;
    static public Planet CurrentPlanet;
    // Start is called before the first frame update
    void Start()
    {
        CurrentPlanet = new Planet();
    }

    void SaveHeader() {
        // Game.Instance.PlayerName = PlayerName.text;
    }

    // Update is called once per frame
    public void UpdatePlanet(Planet CurrentPlanet)
    {
        Name.text = CurrentPlanet.Name;
        Location.text = 
            CurrentPlanet.Position.ToString() + "\n" + CurrentPlanet.System + "\n" + CurrentPlanet.Sector + "\n" + CurrentPlanet.Region;
        Physical.text =
            CurrentPlanet.Class + " planet\nType " + CurrentPlanet.Atmosphere + " atmosphere";
        Faction.text = CurrentPlanet.Faction.Name;
        Population.text = 
            ((CurrentPlanet.Population)).ToString("###,###,###,###,,") + " million " + CurrentPlanet.Demonym;
        Value.text = CurrentPlanet.ValueString();
    }
}
