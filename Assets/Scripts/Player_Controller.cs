﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Vector2 targetPos;
    public float yIncrement;
    public float speed;
    public float MaxHeight;
    public float MinHeight;
    public AudioSource switchLanes;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector2(transform.position.x, transform.position.y);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < MaxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            switchLanes.Play();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > MinHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            switchLanes.Play();
        }
    }
}
