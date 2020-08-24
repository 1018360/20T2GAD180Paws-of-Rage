using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI finalScoreDisplay;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.ToString();
        finalScoreDisplay.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BinObstacle") || other.CompareTag("SewerObstacle"))
        {
            score++;
        }
    }
}
