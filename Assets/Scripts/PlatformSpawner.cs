using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab, breakablePlatformPrefab, lastPlatform;
    private int screenWidth, screenHeight, platformAmount, randomNumber;
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
    }

    void Update()
    {
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 0));

        SpawnPlatform();
    }


    private void SpawnPlatform()
    {
        if (lastPlatform.transform.position.y < cameraPosition.y + 1)
        {
            randomNumber = Random.Range(0, 2);

            if (randomNumber == 0)
            {
                lastPlatform = Instantiate(platformPrefab, new Vector3(cameraPosition.x + Random.Range(-10f, -1f), lastPlatform.transform.position.y + Random.Range(3.5f, 5f)), Quaternion.identity);
            }

            if (randomNumber == 1)
            {
                lastPlatform = Instantiate(breakablePlatformPrefab, new Vector3(cameraPosition.x + Random.Range(-10f, -1f), lastPlatform.transform.position.y + Random.Range(3.5f, 5f)), Quaternion.identity);
            }
        }
    }
}
