using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    private Camera cam;
    private Vector3 cameraPosition;

    void Awake()
    {
        cam = Camera.main;
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        if (player.transform.position.y - 15 > cameraPosition.y)
        {
            cam.transform.position += new Vector3(0, 5, 0) * Time.deltaTime;
        }
    }
}
