using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlavorBehavior : MonoBehaviour
{
    public UICursor m_UICursor;
    public PinchControl2D pinchController;
    public FlavorManager m_flavorManager;

    public GameObject creamObject;
    Renderer cream_renderer;
    public Material flavorMaterial;

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

        cream_renderer = creamObject.GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (pinchController.endPinch)
        {
            if (isConfirmed)
            {
                m_stepmanager.NextStep();
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
            cream_renderer.material = flavorMaterial;

            m_flavorManager.FlavorChecker(gameObject, true);

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
