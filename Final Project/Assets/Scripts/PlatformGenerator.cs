using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> sections;
    public int numOfSections = 30;

    public GameObject endZone;

    public Transform player;

    int whichPlatform;

    Vector3 spawnPosition;

    Vector3 offset = new Vector3(0f, 5.0f, 0f);

    bool reachedEnd = false;

    public GameObject win;

    public AudioSource winSound;

    // Start is called before the first frame update
    void Start()
    {
        win.gameObject.SetActive(false);

        spawnPosition = player.position + offset;

        spawnPosition.x = 2;

        whichPlatform = Random.Range(0, sections.Count);

        Instantiate(sections[whichPlatform], spawnPosition, Quaternion.identity);


        for (int i = 0; i < numOfSections; i++)
        {
            spawnPosition.y += 8f;
            spawnPosition.x = 2;

            whichPlatform = Random.Range(0, sections.Count);

            Instantiate(sections[whichPlatform], spawnPosition, Quaternion.identity);
        }

        //endZone.transform.localEulerAngles = new Vector3(0, 0, 0);

        //Instantiate(endZone, spawnPosition + offset, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) 
        {
            if (player.position.y > spawnPosition.y + 5.0f && !reachedEnd)
            {
                reachedEnd = true;

                win.gameObject.SetActive(true);

                winSound.Play();

                StartCoroutine(Restart());

            }
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(3.0f);

        SceneManager.LoadScene("Bunny Jump");

    }

}






