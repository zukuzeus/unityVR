using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    private Light myLight;
    // Use this for initialization
    void Start () {
        myLight = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameController.gameOver)
        {
            myLight.enabled = false;
        }
    }
}
