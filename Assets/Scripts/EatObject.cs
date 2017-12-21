using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatObject : MonoBehaviour
{
    public Material ObjectNormalMaterial;
    public Material triggerMaterial;
    public bool isPickable;
    public static string kindOfObject;
    private bool playerInArea;
    private bool isPickedUp;
    private string tag;


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
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            isPickedUp = true;
            counterIncrement(kindOfObject, tag);
            Destroy(gameObject);

        }
    }
    public static string getObjectKind()
    {
        return kindOfObject;
    }
    private void placeDown()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton1))
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
            GetComponent<Renderer>().material = triggerMaterial;
            playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Bot")
        {
            this.tag = "";
            playerInArea = false;
            GetComponent<Renderer>().material = ObjectNormalMaterial;
        }
    }
    private void counterIncrement(string pickableKind, string playerOrBot)
    {
        if (playerOrBot == "Player")
        {
            switch (pickableKind)
            {
                case "crumble":
                    ScoreScript.CrumblesCounter++;
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
