using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDucks : MonoBehaviour
{
    public DuckMovement duckPrefab;
    float waitTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime += Time.deltaTime;     //Counts time between ducks spawning

        if (waitTime >= 5f)
        {
            DuckMovement clone;
            clone = Instantiate(duckPrefab, transform.position, transform.rotation);
            clone.player = GameObject.Find("player");
            waitTime = 0f;      //Spawns duck if 5 seconds have passed since last spawn and finds player GameObject to seek out player
        }
    }
}
