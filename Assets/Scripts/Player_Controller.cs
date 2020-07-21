﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float MaxHeight;
    public float MinHeight;
    public int health = 3;
    public Text healthDisplay;
    public GameObject gameOver;
    public AudioSource healthCounter;
    public AudioSource switchLanes;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = health.ToString();
        
        
        if (health <=0)
        {
            gameOver.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 2f);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < MaxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            switchLanes.Play();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > MinHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            switchLanes.Play();
        }
        
    }
}
