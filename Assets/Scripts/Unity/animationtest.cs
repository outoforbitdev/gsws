using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationtest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void raiseWings() {
        GameObject.Find("lambda").GetComponent<Animation>().Play();
    }
}
