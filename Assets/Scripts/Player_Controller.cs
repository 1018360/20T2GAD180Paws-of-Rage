using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float MaxHeight;
    public float MinHeight;
    public int health = 3;
    // Update is called once per frame
    void Update()
    {
        if (health <=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < MaxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > MinHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            
        }
         else if (Input.GetKeyDown(KeyCode.Space))
        {
            ;
        }

        
    }
}
