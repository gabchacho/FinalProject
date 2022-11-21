using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    Touch touch;
    Vector3 touchPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) 
        {
            touch = Input.GetTouch(0);

            touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            Shoot(touchPos);

            /*touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            touchPos.z = 0f;

            transform.position = touchPos;*/
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) 
        {
            Vector3 tap = Utility.ScreenToWorldPos(Input.mousePosition);

            Shoot(tap);
        }
    }


    void Shoot(Vector3 loc)    
    {

        Vector3 newPos = Vector3.Normalize(loc - transform.position);

        //loc.z = 0f;

        transform.up = newPos;

 

        /*if (transform.rotation.z < -50.0f || transform.rotation.z > 50.0f) 
        {
            //Mathf.Clamp(transform.position.z, -50.0f, 50.0f);

            Debug.Log(transform.rotation);

        }*/

        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        /*RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, touchPos);

        if (hitInfo) 
        {
            Debug.Log(hitInfo.transform.name);
        }*/

        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
