using UnityEngine;
using UnityEngine.UI;

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
        if (Game.Instance.Factions.TryGetValue(CurrentPlanet.Faction, out faction))
            Faction.text = faction.Name;
        else
            Faction.text = CurrentPlanet.Faction;
        Population.text = 
            ((CurrentPlanet.Population)).ToString("###,###,###,###,,") + " million " + CurrentPlanet.Demonym;
        Value.text = CurrentPlanet.ValueString();
    }
}
