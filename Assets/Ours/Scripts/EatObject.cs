using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatObject : MonoBehaviour
{
    public Material ObjectNormalMaterial;
    public Material triggerMaterial;
    public bool isPickable;
    public string kindOfObject;
    public static string pickableObject;
    private bool playerInArea;
    private bool isPickedUp;
    private string tag;
    float _waitTimer;

    void start()
    {
        triggerMaterial = GetComponent<Renderer>().material;
        this.tag = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInArea && isPickable)
        {
            if (isPickedUp)
                placeDown();
            else
                pickUp();
        }
    }
    private void pickUp()
    {
        if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton1)) && tag == "Player")
        {
            isPickedUp = true;
            counterIncrement(kindOfObject, tag);
            Destroy(gameObject);

        }
        else if (tag == "Bot" )
        {
            isPickedUp = true;
            pickableObject = kindOfObject;
        }
    }
    private void placeDown()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            isPickedUp = false;
        }
        else if (tag == "Bot")
        {
            isPickedUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Bot")
        {
          
            this.tag = other.tag;
            Debug.Log("tag= " + other.tag);
            if (other.tag == "Player") {
                GetComponent<Renderer>().material = triggerMaterial;
            }          
            playerInArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Bot")
        {
            this.tag = "";
            playerInArea = false;
            if (other.tag == "Player")
            {
                GetComponent<Renderer>().material = ObjectNormalMaterial;
            }         
        }
    }
    public static void counterIncrement(string pickableKind, string playerOrBot)
    {
        if (playerOrBot == "Player")
        {
            switch (pickableKind)
            {
                case "crumble":
                    ScoreScript.CrumblesCounter++;
                    ScoreScript.CrumblesEaten++;
                    Debug.Log("crumbles player= " + ScoreScript.CrumblesCounter);
                    break;
                case "stone":
                    ScoreScript.StoneCounter++;
                    Debug.Log("stones player= " + ScoreScript.StoneCounter);
                    break;
                default:
                    break;
            }
        }
        else if (playerOrBot == "Bot")
        {
            switch (pickableKind)
            {
                case "crumble":
                    ScoreScript.CrumblesCounterBot++;
                    ScoreScript.CrumblesEaten++;
                    Debug.Log("crumbles bot= " + ScoreScript.CrumblesCounterBot);
                    break;
                case "stone":
                    ScoreScript.StoneCounterBot++;
                    Debug.Log("stones bot= " + ScoreScript.StoneCounterBot);
                    break;
                default:
                    break;
            }
        }
    }
}
