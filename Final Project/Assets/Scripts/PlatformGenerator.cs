using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> sections;
    public int numOfSections = 15;

    public float levelWidth = 3f;

    public Transform player;

    int whichPlatform;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = player.position;

        spawnPosition.x = Random.Range(-levelWidth, levelWidth);

        whichPlatform = Random.Range(0, sections.Count);

        Instantiate(sections[whichPlatform], spawnPosition, Quaternion.identity);


        for (int i = 0; i < numOfSections; i++)
        {
            spawnPosition.y += 10f;
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            whichPlatform = Random.Range(0, sections.Count);

            Instantiate(sections[whichPlatform], spawnPosition, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
