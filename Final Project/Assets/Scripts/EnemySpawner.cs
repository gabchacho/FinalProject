using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //public GameObject enem;
    //public List<Transform enemyTrans;
    int whichEnem;

    public List<GameObject> enemList;

    // Start is called before the first frame update
    void Start()
    {

        whichEnem = Random.Range(0, enemList.Count);

        Instantiate(enemList[whichEnem], transform.position, transform.rotation);

        Destroy(gameObject);

        /*int num = Random.Range(0, 10);


        if (num < 5) 
        {
            Instantiate(enem, transform.position, transform.rotation);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
