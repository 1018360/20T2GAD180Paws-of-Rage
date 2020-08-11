using System.Collections;
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
    public GameObject[] lanes;
    public int laneTracker = 1;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = lanes[laneTracker].transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (laneTracker < 2)
            {
                laneTracker++;
                targetPos = lanes[laneTracker].transform.position;
                switchLanes.Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (laneTracker > 0)
            {
                laneTracker--;
                targetPos = lanes[laneTracker].transform.position;
                switchLanes.Play();
            }
        }
    }
}
