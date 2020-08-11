using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Animations;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public AudioSource powerUpSound;
    public float speed;
    public float maxSpeed;
    public float baseSpeed;
    public float speedBoost;
    public float speedBoostTime;
    private bool powerupCollected = false;
    private float timer;
    public float xIncrement;
    Animator dogAnimator;
    



    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            powerupCollected = true;
            if ((speed+=speedBoost) <= maxSpeed)
            {
                foreach (GameObject sewer in GameObject.FindGameObjectsWithTag("SewerObstacle"))
                {
                    sewer.GetComponent<Obstacle>().speed += speedBoost;
                }
                foreach (GameObject bin in GameObject.FindGameObjectsWithTag("BinObstacle"))
                {
                    bin.GetComponent<Obstacle>().speed += speedBoost;
                }
                foreach (GameObject powerup in GameObject.FindGameObjectsWithTag("PowerUp"))
                {
                    powerup.GetComponent<Powerup>().speed += speedBoost;
                }
                
                
            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>().targetPos = new Vector2(Dog.GetComponent<Transform>().position.x + xIncrement, Dog.GetComponent<Transform>().position.y);
            
            dogAnimator.SetBool("DogFacePaint", true);
            powerUpSound.Play();
            GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>().MetalMode.Invoke();
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 5f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        powerupCollected = false;
        dogAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (powerupCollected == true)
        {
            timer += Time.deltaTime;
            if (timer >= speedBoostTime)
            {
                foreach (GameObject sewer in GameObject.FindGameObjectsWithTag("SewerObstacle"))
                {
                    sewer.GetComponent<Obstacle>().speed = baseSpeed;
                }
                foreach (GameObject bin in GameObject.FindGameObjectsWithTag("BinObstacle"))
                {
                    bin.GetComponent<Obstacle>().speed = baseSpeed;
                }
                foreach (GameObject powerup in GameObject.FindGameObjectsWithTag("PowerUp"))
                {
                    powerup.GetComponent<Powerup>().speed = baseSpeed;
                }
                GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>().ChillMode.Invoke();
                
                dogAnimator.SetBool("DogFacePaint", false);
            }
        }
    }
}
