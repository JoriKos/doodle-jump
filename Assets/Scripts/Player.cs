using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera cam;
    private Vector3 cameraPosition;

    void Awake()
    {
        cam = Camera.main;
    }
    
    void Update()
    {
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        if (this.gameObject.transform.position.y < cameraPosition.y)
        {
            Destroy(this.gameObject);
        }
    }
}
