using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour {

    public GameObject player;
    public float cameraHeight = 20.0f;

    void Update()
    {
        Vector3 pos = player.transform.position;
        Vector3 rotation = new Vector3(90, player.transform.eulerAngles.y, 0);
        pos.y += cameraHeight;
        transform.position = pos;
        transform.eulerAngles = rotation;

    }
}
