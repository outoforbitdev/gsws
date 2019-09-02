using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeController : MonoBehaviour
{
    void Start() {
        gameObject.GetComponent<Toggle>().isOn = Game.Instance.IsInvoking("AdvanceTime");
        gameObject.GetComponent<Toggle>().onValueChanged.AddListener((value) => {
            OnChange(value);
        });
    }
    public void OnChange(bool AdvanceTime) {
        if (AdvanceTime)
            Game.Instance.InvokeRepeating("AdvanceTime", 1f, 1f);
        else
            Game.Instance.CancelInvoke("AdvanceTime");
    }
}