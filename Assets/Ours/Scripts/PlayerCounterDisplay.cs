using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PlayerCounterDisplay : MonoBehaviour
{
    const string display = "{0}";
    public string player;
    private Text m_Text;


    private void Start()
    {
        m_Text = GetComponent<Text>();
    }


    private void Update()
    {
        switch (player)
        {
            case "PLAYER":
                m_Text.text = string.Format(display, ScoreScript.CrumblesCounter);
                break;
            case "CPU":
                m_Text.text = string.Format(display, ScoreScript.CrumblesCounterBot);
                break;
            default:
                break;
        }
    }
}

