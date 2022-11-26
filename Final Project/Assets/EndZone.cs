using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public TextMeshProUGUI endZoneText;

    // Start is called before the first frame update
    void Start()
    {
        //endZoneText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) 
        {
            Time.timeScale = 0.0f;

            //endZoneText.gameObject.SetActive(true);
        }
    }
}
