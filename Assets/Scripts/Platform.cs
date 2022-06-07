using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 cameraPosition;
    private Transform objectTransform;
    private GameObject player;
    private BoxCollider2D objectCollider;

    void Start()
    {
        objectCollider = this.gameObject.GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
        objectTransform = this.gameObject.GetComponent<Transform>();
        objectCollider.isTrigger = true;
    }

    void Update()
    {
        if (player.transform.position.y > objectTransform.position.y)
        {
            objectCollider.isTrigger = false;
        }
        else
        {
            objectCollider.isTrigger = true;
        }

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
