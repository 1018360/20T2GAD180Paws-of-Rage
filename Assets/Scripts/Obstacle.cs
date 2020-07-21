using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    private AudioSource obstacleCollision;

    IEnumerator Jump()
    {
        foreach (GameObject sewer in GameObject.FindGameObjectsWithTag("SewerObstacle"))
        {
            sewer.GetComponent<CircleCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject sewer in GameObject.FindGameObjectsWithTag("SewerObstacle"))
        {
            sewer.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        obstacleCollision = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Jump");
        }
    }
        
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            obstacleCollision.Play();
            //player takes damage
            other.GetComponent<Player_Controller>().health -= damage;
            Destroy(gameObject);
        }
    }
}
