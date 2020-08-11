using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;


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
    public Sprite[] backgroundSprite = new Sprite[18];
    
        void OnTriggerEnter2D(Collider2D other)
    {
        GameObject Dog = GameObject.FindGameObjectWithTag("Player");
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
            Dog.GetComponent<Player_Controller>().lanes[0].transform.position = new Vector2(Dog.GetComponent<Player_Controller>().lanes[0].transform.position.x + xIncrement, Dog.GetComponent<Player_Controller>().lanes[0].transform.position.y);
            Dog.GetComponent<Player_Controller>().lanes[1].transform.position = new Vector2(Dog.GetComponent<Player_Controller>().lanes[1].transform.position.x + xIncrement, Dog.GetComponent<Player_Controller>().lanes[1].transform.position.y);
            Dog.GetComponent<Player_Controller>().lanes[2].transform.position = new Vector2(Dog.GetComponent<Player_Controller>().lanes[2].transform.position.x + xIncrement, Dog.GetComponent<Player_Controller>().lanes[2].transform.position.y);
            dogAnimator.SetBool("DogFacePaint", true);
            powerUpSound.Play();
            GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>().MetalMode.Invoke();
            foreach (GameObject background in GameObject.FindGameObjectsWithTag("Background"))
            {
                background.GetComponent < SpriteRenderer>().sprite = backgroundSprite[1];
            }
            foreach (GameObject fence in GameObject.FindGameObjectsWithTag("Fence"))
            {
                fence.GetComponent<SpriteRenderer>().sprite = backgroundSprite[3];
            }
            foreach (GameObject bin in GameObject.FindGameObjectsWithTag("BinObstacle"))
            {
                bin.GetComponent<SpriteRenderer>().sprite = backgroundSprite[5];
            }
            foreach (GameObject hills in GameObject.FindGameObjectsWithTag("Hills"))
            {
                hills.GetComponent<SpriteRenderer>().sprite = backgroundSprite[7];
            }
            foreach (GameObject hills2 in GameObject.FindGameObjectsWithTag("Hills2"))
            {
                hills2.GetComponent<SpriteRenderer>().sprite = backgroundSprite[9];
            }
            foreach (GameObject road in GameObject.FindGameObjectsWithTag("Road"))
            {
                road.GetComponent<SpriteRenderer>().sprite = backgroundSprite[11];
            }
            foreach (GameObject tree in GameObject.FindGameObjectsWithTag("Tree"))
            {
                tree.GetComponent<SpriteRenderer>().sprite = backgroundSprite[13];
            }
            foreach (GameObject powerup in GameObject.FindGameObjectsWithTag("PowerUp"))
            {
                powerup.GetComponent<SpriteRenderer>().sprite = backgroundSprite[15];
            }
            foreach (GameObject sewer in GameObject.FindGameObjectsWithTag("SewerObstacle"))
            {
                sewer.GetComponent<SpriteRenderer>().sprite = backgroundSprite[17];
            }
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
                foreach (GameObject background in GameObject.FindGameObjectsWithTag("Background"))
                {
                    background.GetComponent<SpriteRenderer>().sprite = backgroundSprite[0];
                }
                foreach (GameObject fence in GameObject.FindGameObjectsWithTag("Fence"))
                {
                    fence.GetComponent<SpriteRenderer>().sprite = backgroundSprite[2];
                }
                foreach (GameObject bin in GameObject.FindGameObjectsWithTag("BinObstacle"))
                {
                    bin.GetComponent<SpriteRenderer>().sprite = backgroundSprite[4];
                }
                foreach (GameObject hills in GameObject.FindGameObjectsWithTag("Hills"))
                {
                    hills.GetComponent<SpriteRenderer>().sprite = backgroundSprite[6];
                }
                foreach (GameObject hills2 in GameObject.FindGameObjectsWithTag("Hills2"))
                {
                    hills2.GetComponent<SpriteRenderer>().sprite = backgroundSprite[8];
                }
                foreach (GameObject road in GameObject.FindGameObjectsWithTag("Road"))
                {
                    road.GetComponent<SpriteRenderer>().sprite = backgroundSprite[10];
                }
                foreach (GameObject tree in GameObject.FindGameObjectsWithTag("Tree"))
                {
                    tree.GetComponent<SpriteRenderer>().sprite = backgroundSprite[12];
                }
                foreach (GameObject powerup in GameObject.FindGameObjectsWithTag("PowerUp"))
                {
                    powerup.GetComponent<SpriteRenderer>().sprite = backgroundSprite[14];
                }
                foreach (GameObject sewer in GameObject.FindGameObjectsWithTag("SewerObstacle"))
                {
                    sewer.GetComponent<SpriteRenderer>().sprite = backgroundSprite[16];
                }
                dogAnimator.SetBool("DogFacePaint", false);
            }
        }
    }
}
