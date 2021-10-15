using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDucks : MonoBehaviour
{
    public DuckMovement duckPrefab;
    float waitTime = 0f;
    public Slider playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.value != 0f)
        {
            waitTime += Time.deltaTime;     //Counts time between ducks spawning as long as player is not dead
        }

        if (waitTime >= 5f)
        {
            DuckMovement clone;
            clone = Instantiate(duckPrefab, transform.position, transform.rotation);
            clone.player = GameObject.Find("player");
            waitTime = 0f;      //Spawns duck if 5 seconds have passed since last spawn and finds player GameObject to seek out player
        }
    }
}
