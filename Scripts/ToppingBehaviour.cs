using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToppingBehaviour : MonoBehaviour
{
    public UICursor m_UICursor;
    public PinchControl2D pinchController;
    public ToppingManager m_toppingManager;
    public StepManager m_stepManager;
    



    public GameObject toppingModel;

    private bool startFX = true;
    public ParticleSystem transitionFX;

    public Vector3 originalPosition;

    RectTransform toppingImage;

    private bool isConfirmed;



    // Start is called before the first frame update
    void Start()
    {
        toppingImage = gameObject.GetComponent<RectTransform>();
        originalPosition = toppingImage.anchoredPosition;

        toppingModel.SetActive(false);

        isConfirmed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pinchController.endPinch)
        {
            if (isConfirmed)
            {
                //m_toppingManager.toppingCounter++;
                m_stepManager.NextStep();
            }


        }

    }

    public void Move()
    {
        gameObject.transform.position = m_UICursor.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Button button = collider.GetComponent<Button>();

        if (collider.gameObject.tag == "IceCream" && pinchController.endPinch)
        {
            startFX = !startFX;

            //gameObject.SetActive(false);

            m_toppingManager.ToppingChecker(gameObject, true);

            toppingImage.anchoredPosition = originalPosition;
            toppingModel.SetActive(true);

            //m_toppingManager.toppingCounter++;

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
            //Logic for when unpinched outside of ice cream collider
            toppingImage.anchoredPosition = originalPosition;
        }


    }


}
