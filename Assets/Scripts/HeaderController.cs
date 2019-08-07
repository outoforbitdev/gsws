using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderController : MonoBehaviour
{
    public Text PlayerName;
    public Text FactionName;
    public Text Date;
    public Text Funds;
    // Start is called before the first frame update
    void Start()
    {
        PlayerName.text = Game.Instance.Player.Character.Name;
        FactionName.text = Game.Instance.Faction.Name;
        Date.text = Game.DateToString();
        // Funds.text = (Game.Instance.Faction.Funds.ToString() + " credits");
    }

    void SaveHeader() {
        // Game.Instance.PlayerName = PlayerName.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
