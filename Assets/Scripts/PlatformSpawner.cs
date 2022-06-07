using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab, lastPlatform;
    private int screenWidth, screenHeight, platformAmount;
    private Vector3 cameraPosition;
    private float timer;
    private bool startTimer;

    void Awake()
    {
        screenWidth = Screen.width; //340
        screenHeight = Screen.height; //604
        lastPlatform = GameObject.Find("Platform4");
        startTimer = true;
        timer = 0f;
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 0));
        Instantiate(platformPrefab);
    }

    void Update()
    {
        if (startTimer)
        {
            timer += 1 * Time.deltaTime;

            if (timer > 1f)
            {
                startTimer = false;
                timer = 0;
            }
        }

        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 0));

        SpawnPlatform();
    }


    private void SpawnPlatform()
    {
        
        if (lastPlatform.transform.position.y < cameraPosition.y + 1 && !startTimer)
        {
            startTimer = true;
            Debug.Log(startTimer);
            lastPlatform = Instantiate(platformPrefab, new Vector3(cameraPosition.x + Random.Range(-10f, -1f), lastPlatform.transform.position.y + Random.Range(3.5f, 5f)), Quaternion.identity);
        }
    }
}
