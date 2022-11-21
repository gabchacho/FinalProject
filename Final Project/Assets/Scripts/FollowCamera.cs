using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: This code was taken from Flappy Bird Lab!
public class FollowCamera : MonoBehaviour
{
    public Transform m_target;

    Vector3 m_offset;
    Vector3 m_original;

    // Start is called before the first frame update
    void Start()
    {
        if (null == m_target)
        {
            m_target = FindObjectOfType<Player>().transform;
        }

        m_original = transform.position;
        m_offset = m_original - m_target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (null != m_target)
        {
            Vector3 pos = m_target.position + m_offset;

            pos.z = m_original.z;
            pos.x = m_original.x;
            transform.position = pos;

        }
    }
}
