using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public GameObject objectToRotate;
    public Vector3 m_rotationDirection;
    

    // Update is called once per frame
    void Update()
    {
        objectToRotate.transform.Rotate(m_rotationDirection);
    }
}
