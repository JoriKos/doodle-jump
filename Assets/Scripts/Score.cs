using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreObject;
    private Rigidbody2D player;
    private float score;

    void Awake()
    {
        scoreObject = GameObject.Find("Canvas");
        scoreText = scoreObject.GetComponentInChildren<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.velocity.y > 0)
        {
            score += player.velocity.y;
        }
        score = Mathf.RoundToInt(score);
        scoreText.text = "Score: " + score.ToString();
    }
}
