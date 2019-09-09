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
        PlayerName.text = Game.Instance.Player.Character;
        FactionName.text = Game.Instance.GetFactionFromString(Game.Instance.Player.Faction).Name;
        Funds.text = Game.CreditString(Game.GetPlayerGovernment().Budget.Balance);
        Date.text = Game.DateToString();
    }

    void SaveHeader() {
        // Game.Instance.PlayerName = PlayerName.text;
    }

    // Update is called once per frame
    void Update()
    {
        Funds.text = Game.CreditString(Game.GetPlayerGovernment().Budget.Balance);
        Date.text = Game.DateToString();
    }
}
