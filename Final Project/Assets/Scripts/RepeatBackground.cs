using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Bounds m_bounds;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponentInChildren<Renderer>();
        if (null == renderer)
        {
            Debug.LogError("RepeatBackground with no renderer");
            Destroy(this);
        }
        m_bounds = renderer.bounds;
    }

    // Update is called once per frame
    void Update()
    {

        //getting the rightmost image, which will be the most recent in the set of images, so the final index
        Transform rightChild = transform.GetChild(transform.childCount - 1);

        Renderer rightRnd = rightChild.GetComponent<Renderer>();

        //Use Renderer.bounds to figure out the right-most edge of that renderer (in world-space)
        Bounds rightBounds = rightRnd.bounds;

        Vector3 viewRight = Camera.main.WorldToViewportPoint(rightBounds.max);

        if (viewRight.y < 1.0)
        {
            //a new tile must be added
            GameObject newTile = Instantiate(rightChild.gameObject); //take the tile and make a copy

            Vector3 newPos = rightChild.position;

            newPos.y += m_bounds.size.y;

            newTile.transform.position = newPos;

            newTile.transform.SetParent(transform);
        }

        {

            /*
             Get the left-most copy of “Image”
            We arranged the children from left-to-right so the left-most is the first one
            Get the Renderer and the Bounds to find the right edge of the left-most child
            Convert that right edge position into view-space
            
             */

            Transform leftChild = transform.GetChild(0);

            Renderer leftRnd = leftChild.GetComponent<Renderer>();

            Bounds leftBounds = leftRnd.bounds;

            Vector3 viewLeft = Camera.main.WorldToViewportPoint(leftBounds.max);

            //If that right edge is off the left of the screen(less than 0.0f),

            if (viewLeft.y < 0.0f)
            {
                //Delete the child with Destroy()
                Destroy(leftChild.gameObject);
            }


        }
    }
}
