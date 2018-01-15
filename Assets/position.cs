using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OVRInput.Update(); // need to be called for checks below to work

        if (OVRInput.Get(OVRInput.Button.DpadLeft))
        {
            print("left button pressed");
        }
        if (OVRInput.Get(OVRInput.Button.DpadRight))
        {
            print("right button pressed");
        }
        if (OVRInput.Get(OVRInput.Button.One))
        {
            print("round button pressed");
        }
	}
}
