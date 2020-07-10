using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlavorManager : MonoBehaviour
{
    public Sprite currentChoiceImage;
    private Sprite originalImage;

    public GameObject[] flavors;
    private GameObject currentFlavor;
    private GameObject otherFlavor;

    private bool isConfirmed = false;

    public StepManager stepManager;

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    public void FlavorChecker(GameObject flavorChoice, bool isCurrent)
    {



        foreach (GameObject flavor in flavors)
        {

            //originalImage = flavor.GetComponent<Image>().sprite;

            if (flavor.name != flavorChoice.name)
            {
                //otherFlavor = flavor;

                //otherFlavor.GetComponent<Image>().sprite = originalImage;
                //Debug.Log("NOT the current flavor");
                flavor.SetActive(true);
                
            }
            else
            {

                //currentFlavor = flavor;

                //currentFlavor.GetComponent<Image>().sprite = currentChoiceImage;
                Debug.Log("Current flavor is: " + flavor.name);

                
            }
        }
    }

    public void ConfirmChoice()
    {
        //StartCoroutine(TestFunction());
        stepManager.NextStep();
    }

    

    
    

}
