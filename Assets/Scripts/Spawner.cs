using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public int roundCount;
    public float decreaseTime;
    public float minTime = 0.65f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            ++roundCount;

            switch (roundCount)
            {
                case 1:
                    Instantiate(obstaclePatterns[19], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;
                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                        break;

                case 2:
                    Instantiate(obstaclePatterns[19], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;
                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                    break;

                case 3:
                    Instantiate(obstaclePatterns[19], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;
                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                    break;

                case 4:
                    Instantiate(obstaclePatterns[13], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;
                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                    break;

                case 5:
                    Instantiate(obstaclePatterns[14], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;
                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                    break;

                case 6:
                    Instantiate(obstaclePatterns[15], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;
                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                    break;

                case 7:
                    Instantiate(obstaclePatterns[14], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;
                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                    break;

                case 8:
                    Instantiate(obstaclePatterns[13], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;
                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                    break;

                default:
                int rand = Random.Range(0, obstaclePatterns.Length);
                Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
                timeBtwSpawn = startTimeBtwSpawn;
                if (startTimeBtwSpawn > minTime)
                {
                     startTimeBtwSpawn -= decreaseTime;
                }
                    break;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
