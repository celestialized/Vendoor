using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOTMBehaviour : MonoBehaviour
{
    public UICursor m_UICursor;
    public PinchControl2D pinchController;
    public OOTMManager m_OOTMManager;
    

    public GameObject ollyOfTheMonthModel;
    public GameObject defaultIceCreamModel;
 

    private bool startFX = true;
    public ParticleSystem transitionFX;

    public Vector3 originalPosition;

    RectTransform flavorImage;


    public StepManager m_stepmanager;
    private bool isConfirmed;


    // Start is called before the first frame update
    void Start()
    {
        isConfirmed = false;

        flavorImage = gameObject.GetComponent<RectTransform>();
        originalPosition = flavorImage.anchoredPosition;

        if (ollyOfTheMonthModel.activeSelf)
        {
            ollyOfTheMonthModel.SetActive(false);
        }



    }

    // Update is called once per frame
    void Update()
    {

        if (pinchController.endPinch)
        {
            if (isConfirmed)
            {
                m_stepmanager.GoToStep(2);
            }


        }
    }

    public void Move()
    {
        gameObject.transform.position = m_UICursor.transform.position;
    }



    private void OnTriggerStay2D(Collider2D collider)
    {


        

        if (collider.gameObject.tag == "IceCream" && pinchController.endPinch)
        {



            startFX = !startFX;

            

            ollyOfTheMonthModel.SetActive(true);
            defaultIceCreamModel.SetActive(false);

            

            m_OOTMManager.OTTMChecker(gameObject, true);

            flavorImage.anchoredPosition = originalPosition;

            isConfirmed = true;





            startFX = true;

            if (startFX)
            {
                if (!transitionFX.isPlaying)
                {
                    transitionFX.Play();

                }

            }
            else
            {
                if (transitionFX.isPlaying)
                {
                    transitionFX.Stop();
                }
            }
        }
        else if (pinchController.endPinch)
        {
            flavorImage.anchoredPosition = originalPosition;
        }


    }




}
