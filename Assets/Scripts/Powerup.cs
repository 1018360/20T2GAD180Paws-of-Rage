using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public AudioSource powerUpSound;
    public float speed;
    public float maxSpeed;
    public float modeSwitch = 1f;
    public float metalMultiplier;
    public enum DogMood { Metal, Chill };
    DogMood dogFeels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (modeSwitch >= 5f)
        {
            GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>().MetalMode.Invoke();
            modeSwitch--;
        }
        else if (modeSwitch < 5f)
        {
            GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>().ChillMode.Invoke();
        }
        switch (dogFeels)
        {
            case DogMood.Metal:
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("SewerObstacle"))
                {
                    go.GetComponent<Obstacle>().modeSwitch *= metalMultiplier;
                }
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("BinObstacle"))
                {
                    go.GetComponent<Obstacle>().modeSwitch *= metalMultiplier;
                }
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("PowerUp"))
                {
                    go.GetComponent<Powerup>().modeSwitch *= metalMultiplier;
                }
                break;

            case DogMood.Chill:
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("SewerObstacle"))
                {
                    go.GetComponent<Obstacle>().modeSwitch = 1;
                }
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("BinObstacle"))
                {
                    go.GetComponent<Obstacle>().modeSwitch = 1;
                }
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("PowerUp"))
                {
                    go.GetComponent<Powerup>().modeSwitch = 1;
                }
                break;

            default:
                Debug.Log("Hit the default state of the switch!");
                break;
        }

    }

    public void SpeedPower()
    {
        if (speed <= maxSpeed)
        {
            speed *= metalMultiplier;
        }
    }

    public void SpeedNerf()
    {
        speed = 5;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dogFeels = DogMood.Metal;
            powerUpSound.Play();
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 2f);
        }
        else
        {
            dogFeels = DogMood.Chill;
        }
    }

}
