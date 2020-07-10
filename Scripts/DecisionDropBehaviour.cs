using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionDropBehaviour : MonoBehaviour
{
    public UICursor m_UICursor;
    public PinchControl2D pinchController;
    public StepManager m_stepmanager;

    public GameObject extraOllyDrop;
    public GameObject checkoutDrop;
    public GameObject decisionBowl;

    public Vector3 originalPosition;
    RectTransform dropImage;

    public bool isCheckoutDrop;
    public bool isExtraOllyDrop;

    private bool isConfirmed;

    // Start is called before the first frame update
    void Start()
    {

        isConfirmed = false;
        dropImage = gameObject.GetComponent<RectTransform>();
        originalPosition = dropImage.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isConfirmed)
        {
            m_stepmanager.NextStep();

        }

        if (pinchController.endPinch)
        {
            


        }
    }

    public void Move()
    {
        gameObject.transform.position = m_UICursor.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "DecisionBowl" && pinchController.endPinch)
        {
            isConfirmed = true;
        }

        else if (pinchController.endPinch)
        {
            dropImage.anchoredPosition = originalPosition;
        }
    }


    public void CheckoutDrop()
    {
        Debug.Log("this is a checkout drop");
        isConfirmed = true;

    }

    public void ExtraOllyDrop()
    {
        Debug.Log("this is a extra olly drop");
    }
}
