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
        CurrentPlanet = new Planet("[Planet Name]", new Coordinate(0,0,0), new string[0]);
    }

    void SaveHeader() {
        // Game.Instance.PlayerName = PlayerName.text;
    }

    // Update is called once per frame
    public void UpdatePlanet(Planet CurrentPlanet)
    {
        Name.text = CurrentPlanet.Name;
        Location.text = 
            CurrentPlanet.Coordinates.ToString() + "\n" + CurrentPlanet.System + "\n" + CurrentPlanet.Sector + "\n" + CurrentPlanet.Region;
        Physical.text =
            CurrentPlanet.Class + " planet\nType " + CurrentPlanet.AtmosphereType.ToString() + " atmosphere";
        Faction faction;
        Faction.text = Game.DB.GetFaction(CurrentPlanet.Faction).Name;
        Population.text = 
            ((CurrentPlanet.Population)).ToString("###,###,###,###,,") + " million " + CurrentPlanet.Demonym;
        Value.text = CurrentPlanet.ValueString();
    }
}
