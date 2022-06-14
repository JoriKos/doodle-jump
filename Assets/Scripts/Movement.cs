using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb;
    private Vector2 upForce;
    private Vector3 mousePos;
    private Transform objectTransform;
    private Vector3 cameraPosition;

    void Awake()
    {
        objectTransform = this.gameObject.GetComponent<Transform>();
        speed = 100;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        upForce = new Vector2(0, 10 * speed);
    }

    void Update()
    {
        if (rb.velocity.y > 10f)
        {
            rb.velocity = new Vector2(0, 10f);
        }

        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)); //Get camera boundaries

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get position of the mouse

        objectTransform.Translate(mousePos.x, 0, 0); //Use mouse's X position to move cube

        //If the player's x coordinates exceed that of the mouse, set the position to be that of the mouse
        if (objectTransform.position.x < mousePos.x)  //left
        {
            objectTransform.position = new Vector2(mousePos.x, objectTransform.position.y);
        }

        if (objectTransform.position.x > mousePos.x) //right
        {
            objectTransform.position = new Vector2(mousePos.x, objectTransform.position.y);
        }

        //Clamp player to screen
        objectTransform.position = new Vector2(Mathf.Clamp(objectTransform.position.x, cameraPosition.x - 11, cameraPosition.x), objectTransform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") //When hitting platforms, jump up
        {
            rb.AddForce(upForce);
        }

        if (collision.gameObject.tag == "BreakablePlatform") //When hitting breakable platforms, jump up and destroy platform
        {
            rb.AddForce(upForce);
            Destroy(collision.gameObject);
        }
    }
}
