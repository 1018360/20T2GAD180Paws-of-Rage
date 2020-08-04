using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public AudioSource powerUpSound;
    public float speed;
    public bool isMetal = false;
    public float modeswitch;

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
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (modeswitch >= 1)
        {
            isMetal = true;
        }
        else
        {
            isMetal = false;
        }
        speedPower();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            powerUpSound.Play();
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("SewerObstacle"))
            {
                go.GetComponent<Obstacle>().modeswitch = 2f;
            }
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("BinObstacle"))
            {
                go.GetComponent<Obstacle>().modeswitch = 2f;
            }
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("PowerUp"))
            {
                go.GetComponent<Powerup>().modeswitch = 2f;
            }
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }

}
