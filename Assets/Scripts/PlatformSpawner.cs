using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject[] platforms;
    private int screenWidth, screenHeight;
    private Vector3 cameraPosition;

    void Awake()
    {
        screenWidth = Screen.width; //340
        screenHeight = Screen.height; //604
    }

    void Update()
    {
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
    }


    private void SpawnPlatform()
    {

    }
}
