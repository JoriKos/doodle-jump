using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreObject;
    private Rigidbody2D player;
    private float score, maxHeight;

    void Awake()
    {
        scoreObject = GameObject.Find("Canvas");
        scoreText = scoreObject.GetComponentInChildren<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        maxHeight = 0;
        score = 0;
    }
    
    void Update()
    {
        if (player.velocity.y > 0 && player.transform.position.y > maxHeight)
        {
            score += player.velocity.y;
        }

        if (player.transform.position.y > maxHeight)
        {
            maxHeight = player.transform.position.y;
        }

        score = Mathf.RoundToInt(score);
        scoreText.text = "Score: " + score.ToString();
    }
}
