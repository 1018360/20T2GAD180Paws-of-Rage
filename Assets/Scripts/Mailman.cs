using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mailman : MonoBehaviour
{
    public Vector2 targetPos;
    public float speed;
    public GameObject[] lanes;
    public int laneTracker = 1;
    public GameObject winner;
    public bool hasWon;
    // Start is called before the first frame update
    void Start()
    {
        hasWon = false;
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
        if (Input.GetKeyDown(KeyCode.R) && hasWon == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Q) && hasWon == true)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasWon = true;
            winner.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
