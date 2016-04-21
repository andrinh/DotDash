using UnityEngine;
using System.Collections;

public class HazardSpawnController : MonoBehaviour {

    public GameObject hazard;
    public Vector2 spawnValues;
    public float hazardCount;
    public float spawnWait;
    public float startWait;

    public float minHorizontalSpeed;
    public float maxHorizontalSpeed;
    public float minVerticalSpeed;
    public float maxVerticalSpeed;

    void Start()
    {
        StartCoroutine(spawnWaves());
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                spawnTopBubble();
                spawnBottomBubble();
                yield return new WaitForSeconds(spawnWait);
            }

            if (maxVerticalSpeed < 7)
            {
                minVerticalSpeed += 0.5f;
                maxVerticalSpeed += 0.5f;
            }
            else if(maxHorizontalSpeed < 4)
            {
                maxHorizontalSpeed += 1;
                minHorizontalSpeed -= 1;
            }
            if (spawnWait >= 0.5)
            {
                spawnWait -= 0.1f;
            }
        }
    }

    void spawnTopBubble()
    {
        Quaternion spawnRotation = Quaternion.identity;
        Vector2 spawnPosition = new Vector2((Random.Range(-spawnValues.x, spawnValues.x)), spawnValues.y);
        GameObject bubbleHazard = (GameObject)Instantiate(hazard, spawnPosition, spawnRotation);
        bubbleHazard.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(minHorizontalSpeed, maxHorizontalSpeed), -1 * Random.Range(minVerticalSpeed, maxVerticalSpeed));
    }

    void spawnBottomBubble()
    {
        Quaternion spawnRotation = Quaternion.identity;
        Vector2 spawnPosition = new Vector2((Random.Range(-spawnValues.x, spawnValues.x)), -spawnValues.y);
        GameObject bubbleHazard = (GameObject)Instantiate(hazard, spawnPosition, spawnRotation);
        bubbleHazard.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(minHorizontalSpeed, maxHorizontalSpeed), Random.Range(minVerticalSpeed, maxVerticalSpeed));
    }
}
