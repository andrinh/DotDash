using UnityEngine;
using System.Collections;

public class MainMenuSpawner : MonoBehaviour {

    public GameObject hazard;
    public Vector2 spawnValues;
    public float spawnWait;
    public float startWait;

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
            spawnTopBubble();
            spawnBottomBubble();
            yield return new WaitForSeconds(spawnWait);
        }
    }

    void spawnTopBubble()
    {
        Quaternion spawnRotation = Quaternion.identity;
        Vector2 spawnPosition = new Vector2((Random.Range(-spawnValues.x, spawnValues.x)), spawnValues.y);
        GameObject bubbleHazard = (GameObject)Instantiate(hazard, spawnPosition, spawnRotation);
        bubbleHazard.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * Random.Range(minVerticalSpeed, maxVerticalSpeed));
    }

    void spawnBottomBubble()
    {
        Quaternion spawnRotation = Quaternion.identity;
        Vector2 spawnPosition = new Vector2((Random.Range(-spawnValues.x, spawnValues.x)), -spawnValues.y);
        GameObject bubbleHazard = (GameObject)Instantiate(hazard, spawnPosition, spawnRotation);
        bubbleHazard.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Random.Range(minVerticalSpeed, maxVerticalSpeed));
    }
}
