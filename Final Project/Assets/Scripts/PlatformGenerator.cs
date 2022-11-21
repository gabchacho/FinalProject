using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> sections;
    public int numOfSections = 15;

    //public float levelWidth = 2f;

    public Transform player;

    int whichPlatform;

    Vector3 offset = new Vector3(0f, 7.0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = player.position + offset;

        //spawnPosition.x = Random.Range(-levelWidth, levelWidth);

        whichPlatform = Random.Range(0, sections.Count);

        Instantiate(sections[whichPlatform], spawnPosition, Quaternion.identity);


        for (int i = 0; i < numOfSections; i++)
        {
            spawnPosition.y += 10f;
            //spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            whichPlatform = Random.Range(0, sections.Count);

            Instantiate(sections[whichPlatform], spawnPosition, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
