using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public bool isMetal;
    public int modeswitch;
    public int damage = 1;
    public AudioSource obstacleCollision;
    public AudioSource jumpSound;
    

    IEnumerator ObstacleJump()
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
    IEnumerator BigDog()
    {
        foreach (GameObject dog in GameObject.FindGameObjectsWithTag("Player"))
        {
            dog.transform.localScale = new Vector3(2, 2, 1);
        }
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject dog in GameObject.FindGameObjectsWithTag("Player"))
        {
            dog.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    IEnumerator PowerupJump()
    {
        foreach (GameObject powerup in GameObject.FindGameObjectsWithTag("PowerUp"))
        {
            powerup.GetComponent<CircleCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject powerup in GameObject.FindGameObjectsWithTag("PowerUp"))
        {
            powerup.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("ObstacleJump");
            StartCoroutine("PowerupJump");
            StartCoroutine("BigDog");
            jumpSound.Play();
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            obstacleCollision.Play();
            //player takes damage
            other.GetComponent<PlayerHealth>().health -= damage;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }

    void speedPower()
    {
        if (isMetal == true)
        {
            modeswitch--;
            speed--;
            if (modeswitch < 1)
            {
                isMetal = false;
            }
        }
        else
        {
            modeswitch++;
            speed++;
            if (modeswitch > 5)
            {
                isMetal = true;
            }
        }
    }
}