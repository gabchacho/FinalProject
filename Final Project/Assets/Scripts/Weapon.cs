using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    Touch touch;
    Vector3 touchPos;
    float timer;
    bool shot = false;

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

        timer -= Time.deltaTime;

        if (timer < 0f && shot)
        {
            shot = false;

            timer = 0.2f;
        }

        //if (!shot) 
        //{
            //these two lines aim at the player's tap
            Vector3 newPos = Vector3.Normalize(loc - transform.position);
            transform.up = newPos; //we need to aim at the point where the player clicked before clamping

            Vector3 angles = transform.localEulerAngles; //this calculates the euler angles

            if (transform.localEulerAngles.z > 90 && transform.localEulerAngles.z < 180)
            {
                angles.z = 90.0f;
            }

            if (transform.localEulerAngles.z > 180 && transform.localEulerAngles.z < 270)
            {
                angles.z = 270.0f;
            }

            transform.localEulerAngles = angles;

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            shot = true;
        //}

 

    }
}
