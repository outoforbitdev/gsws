using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GSWS;

public class HeaderController : MonoBehaviour
{
    public Text PlayerName;
    public Text FactionName;
    public Text Date;
    public Text Funds;
    // Start is called before the first frame update
    void Start()
    {
        PlayerName.text = Game.DB.GetPlayerCharacter().Name;
        FactionName.text = Game.DB.GetPlayerFaction().Name;
        Funds.text = Game.CreditString(Game.DB.GetPlayerGovernment().Budget.Balance);
        Date.text = Game.DB.GetDateString();
    }

    void SaveHeader() {
        // Game.Instance.PlayerName = PlayerName.text;
    }

    // Update is called once per frame
    void Update()
    {
        Funds.text = Game.CreditString(Game.DB.GetPlayerGovernment().Budget.Balance);
        Date.text = Game.DB.GetDateString();
    }
}
