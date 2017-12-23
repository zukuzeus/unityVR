using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int CrumblesCounter;
    public static int StoneCounter;
    public static int CrumblesCounterBot;
    public static int StoneCounterBot;
    public static int CrumblesEaten;
    public Slider pointsbar;

    // Use this for initialization
    void Start()
    {
        CrumblesCounter = 0;
        StoneCounter = 0;
        CrumblesCounterBot = 0;
        StoneCounterBot = 0;
        CrumblesEaten=0;
        pointsbar.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrumblesEaten != 0) {
            pointsbar.value = CalculatePoints();
        }
        
    }

    float CalculatePoints()
    {
        return (float)CrumblesCounter / CrumblesEaten;
    }
}
