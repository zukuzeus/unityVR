using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static bool gameOver;
    public Text Text;
    //public Text VictoryText;
    //public Text InfoText;
    //public GameObject player;
    private Light myLight;

    // Use this for initialization
    void Start () {
        gameOver = false;
        Text.text = "";
       // myLight = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    myLight.enabled = !myLight.enabled;
        //    myLight.color = Color.red;
        //}
        if (gameOver) {
            if (ScoreScript.PlayerLifes > 0){
                if (ScoreScript.CrumblesCounter > ScoreScript.CrumblesCounterBot)
                {
                    Text.text = "VICTORY";
                    Text.color = Color.green;
                  //  InfoText.text = "PRESS Q TO QUIT GAME";
                }
                else
                {
                   Text.text = "GAME OVER";
                   Text.color = Color.red;
                    // InfoText.text = "PRESS Q TO QUIT GAME";
                }
            }
            else {
               Text.text = "YOU DIED";
               Text.color = Color.red;
                // InfoText.text = "PRESS Q TO QUIT GAME";
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
                Debug.Log("PLAYER QUIT THE GAME" );
            }
        }	
	}
}
