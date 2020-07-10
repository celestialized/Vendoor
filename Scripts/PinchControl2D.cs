using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class PinchControl2D : MonoBehaviour
{
    

    protected PinchDetector m_pinchDetector;
    public GameObject leapHand;



    public bool startPinch;
    public bool isPinching;
    public bool endPinch;

    protected Vector3 pinchPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        isPinching = false;

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
            
            OnStartPinch();

        }

        else if (endPinch)
        {
            

            OnRelease();
        }
    }
    public void OnStartPinch()
    {
        //Debug.Log(leapHand.name + " has started pinching");

        
    }

    public void OnRelease()
    {
        //Debug.Log(leapHand.name + " has stopped pinching");
        
    }

}
