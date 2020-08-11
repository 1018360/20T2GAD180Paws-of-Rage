using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailman : MonoBehaviour
{
    public Vector2 targetPos;
    public float speed;
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
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (laneTracker > 0)
            {
                laneTracker--;
                targetPos = lanes[laneTracker].transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Winner!!!!");
        }
    }
}
