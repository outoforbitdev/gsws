using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using GSWS;

public partial class Game : MonoBehaviour
{
    public void StartTime() {
        InvokeRepeating("AdvanceTime", 1f, 1f);
    }
    public void StopTime() {
        CancelInvoke("AdvanceTime");
    }
    public void AdvanceTime() {
        Debug.Log(DB.GetDateString());
        Game.DB.AdvanceTime();
        Debug.Log("b00");
    }
}