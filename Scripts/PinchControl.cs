using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class PinchControl : MonoBehaviour
{
    public float forceSpringConstant;

    public Collider objectGrabbed;
    public GameObject leapHand;

    public float magnetDistance;

    protected PinchDetector m_pinchDetector;

    protected bool isPinching;
    protected bool startPinch;
    protected bool endPinch;

    protected Vector3 pinchPosition;
    protected Vector3 newPosition;

    

    // Start is called before the first frame update
    void Start()
    {
        isPinching = false;
        objectGrabbed = null;

        m_pinchDetector = leapHand.GetComponent<PinchDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        startPinch = m_pinchDetector.DidStartPinch;
        endPinch = m_pinchDetector.DidEndPinch;
        isPinching = m_pinchDetector.IsPinching;

        if (startPinch)
        {
            pinchPosition = m_pinchDetector.Position;
            OnStartPinch(pinchPosition);
            
        }

        else if (endPinch)
        {
            OnRelease();
        }

        if (isPinching && objectGrabbed != null)
        {
            pinchPosition = m_pinchDetector.Position;
            newPosition = pinchPosition - objectGrabbed.transform.position;
            // Any object that should be grabbed must include a Rigidbody
            Rigidbody objectRB = objectGrabbed.GetComponent<Rigidbody>();
            if (objectRB.isKinematic) objectRB.isKinematic = false;
            if (!objectRB.useGravity) objectRB.useGravity = true;
            // Accelerates grabbed object towards the pinch
            objectRB.AddForce(forceSpringConstant * newPosition);
            objectGrabbed.transform.rotation = m_pinchDetector.Rotation;
        }
    }

    /** Finds an object to grab and grabs it. */
    void OnStartPinch(Vector3 pinchPosition)
    {
        Debug.Log(leapHand.name + " has started pinching");

        // Checks if there are objects around and grabs the closest one
       Collider[] close_things = Physics.OverlapSphere(pinchPosition, magnetDistance);
        for (int j = 0; j < close_things.Length; ++j)
        {
            float distance = Vector3.Distance(pinchPosition, close_things[j].transform.position);
            if (close_things[j].GetComponent<Rigidbody>() != null && distance < magnetDistance && !close_things[j].transform.IsChildOf(transform))
            {
                objectGrabbed = close_things[j];
            }
        }
    }

    void OnRelease()
    {
        Debug.Log(leapHand.name + " has stopped pinching");
        objectGrabbed = null;
    }

}
