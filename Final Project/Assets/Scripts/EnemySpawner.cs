using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enem;
    //public Transform enemyTrans;

    //public List<GameObject> enemList;

    // Start is called before the first frame update
    void Start()
    {

        int num = Random.Range(0, 10);


        if (num < 5) 
        {
            Instantiate(enem, transform.position, transform.rotation);
        }

        Destroy(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
