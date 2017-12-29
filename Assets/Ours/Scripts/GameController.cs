using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static bool gameOver;
    public Text GameOverText;
    public Text VictoryText;
    public Text InfoText;
    public GameObject player;

    // Use this for initialization
    void Start () {
        gameOver = false;
        GameOverText.text = "";
        VictoryText.text = "";
        InfoText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver) {
            if (ScoreScript.PlayerLifes > 0){
                if (ScoreScript.CrumblesCounter > ScoreScript.CrumblesCounterBot)
                {
                    VictoryText.text = "VICTORY";
                    InfoText.text = "PRESS Q TO QUIT GAME";
                }
                else
                {
                    GameOverText.text = "GAME OVER";
                    InfoText.text = "PRESS Q TO QUIT GAME";
                }
            }
            else {
                GameOverText.text = "YOU DIED";
                InfoText.text = "PRESS Q TO QUIT GAME";
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
                Debug.Log("PLAYER QUIT THE GAME" );
            }
        }	
	}
}
