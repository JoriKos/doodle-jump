using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 cameraPosition;
    private Transform objectTransform;

    void Start()
    {
        objectTransform = this.gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));

        if (objectTransform.position.y < cameraPosition.y)
        {
            Destroy(this.gameObject);
        }

        /*
        if (objectTransform.position.y - 20 > cameraPosition.y)
        {
            Debug.Log("Spawned");
        }
        */
    }
}
