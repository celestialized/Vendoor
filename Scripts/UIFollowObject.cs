using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIFollowObject : MonoBehaviour
{
    public GameObject objectMesh;
    public RectTransform movingObject;
    public Vector3 offset;
    
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    public void MoveObject()
    {
        Vector3 pos = objectMesh.transform.position + offset;
        
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }
}
