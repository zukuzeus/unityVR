﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HeartUI.sprite = HeartSprites[ScoreScript.PlayerLifes];
	}
}
