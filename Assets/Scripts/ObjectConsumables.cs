using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectConsumables : MonoBehaviour {
    public static int CrumblesCounterPlayer;
    public static int StoneCounterPlayer;
    public static int CrumblesCounterBot;
    public static int StoneCounterBot;
    // Use this for initialization
    void Start () {
        CrumblesCounterPlayer = 0;
        StoneCounterPlayer = 0;
        CrumblesCounterBot = 0;
        StoneCounterBot = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
