using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    int whichEnem;

    public List<GameObject> enemList;

    // Start is called before the first frame update
    void Start()
    {
        whichEnem = Random.Range(0, enemList.Count);


        int num = Random.Range(0, 10);

        if (num < 7) 
        {
            //Instantiate(enem, transform.position, transform.rotation);
            Instantiate(enemList[whichEnem], transform.position, transform.rotation);
        }

        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
