using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamVisualizer : MonoBehaviour
{

    public UICursor m_UICursor;
    public PinchControl2D pinchController;

    public GameObject cursorAssist;
    
    public GameObject objectToRotate;
    private Quaternion initialPose;

    public Camera renderCamera;

    public float cameraSize;
    public float minCameraSize;
    public float maxCameraSize;

    private float fadeCursor;

    [Header("Rotation Speed - Higher values cause higher rotation drag/slowdown ")]
    public float rotationSpeed;

    public bool rotateBackToOriginalPosition = true;
   

   


    // Start is called before the first frame update
    void Start()
    {

        if (cursorAssist.activeSelf)
        {
            cursorAssist.SetActive(false);
        }
        cameraSize = minCameraSize;

        initialPose = objectToRotate.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pinchController.isPinching)
        {
            cameraSize += 1.0f * (Time.deltaTime * 2);

            if (cameraSize > minCameraSize)
            {
                cameraSize = minCameraSize;
            }
            renderCamera.orthographicSize = cameraSize;

            if (rotateBackToOriginalPosition)
            {
                objectToRotate.transform.rotation = Quaternion.Lerp(objectToRotate.transform.rotation, initialPose, Time.deltaTime * 1f);
            }
            
        }
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        cursorAssist.SetActive(true);

        fadeCursor += 0.0f;

        //Debug.Log("Entered Render Texture Collider");
        if (pinchController.isPinching)
        {
            objectToRotate.transform.Rotate(0.0f, -m_UICursor.transform.position.x/rotationSpeed, 0.0f, Space.Self);

            cameraSize -= 1.0f * (Time.deltaTime * 2);

            if (cameraSize < maxCameraSize)
            {
                cameraSize = maxCameraSize;
            }

            renderCamera.orthographicSize = cameraSize;

            cursorAssist.SetActive(false);
        }


        else
        {

           

            if (fadeCursor > 1)
            {
                fadeCursor = 1;
            }

            


        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        cursorAssist.SetActive(false);
    }
}
