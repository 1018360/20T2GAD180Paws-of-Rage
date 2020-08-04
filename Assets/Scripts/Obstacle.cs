using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public bool isMetal = false;
    public float modeswitch;
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
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("MetalFlames"))
        {
            go.GetComponent<ParticleSystem>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (modeswitch >= 1)
        {
            isMetal = true;
        }
        else
        {
            isMetal = false;
        }
        speedPower();
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
        if (isMetal)
        {
            modeswitch += 0.1f;
            speed = 7;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("MetalFlames"))
            {
                go.GetComponent<ParticleSystem>().Play();
            }
            Debug.Log("Metal!");
        }
        else
        {
            modeswitch -= 0.2f;
            speed = 5;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("MetalFlames"))
            {
                go.GetComponent<ParticleSystem>().Stop();
            }

        }
    }
}