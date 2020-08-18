using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Vector2 targetPos;
    public float speed;
    public AudioSource switchLanes;
    public GameObject[] lanes;
    public int laneTracker = 1;
    public AudioSource jumpSound;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("ObstacleJump");
            jumpSound.Play();
        }
    }

    IEnumerator ObstacleJump()
    {
        foreach (GameObject sewer in GameObject.FindGameObjectsWithTag("SewerObstacle"))
        {
            sewer.GetComponent<CircleCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject sewer in GameObject.FindGameObjectsWithTag("SewerObstacle"))
        {
            sewer.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    public void MoveWithLanes()
    {
        targetPos = lanes[laneTracker].transform.position;
    }
}
