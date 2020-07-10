using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOTMManager : MonoBehaviour
{
    public Sprite currentChoiceImage;
    private Sprite originalImage;

    public GameObject[] ootms;
    private GameObject currentOOTM;
    private GameObject otherOTTM;

    public GameObject defaultIceCream;

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

    public void OTTMChecker(GameObject ottmChoice, bool isCurrent)
    {



        foreach (GameObject ottm in ootms)
        {

            //originalImage = flavor.GetComponent<Image>().sprite;

            if (ottm.name != ottmChoice.name)
            {
                //otherFlavor = flavor;

                //otherFlavor.GetComponent<Image>().sprite = originalImage;
                //Debug.Log("NOT the current flavor");
                ottm.SetActive(true);

            }
            else
            {

                //currentFlavor = flavor;

                //currentFlavor.GetComponent<Image>().sprite = currentChoiceImage;
                Debug.Log("Current OOTM is: " + ottm.name);


            }
        }
    }

    public void ConfirmChoice()
    {
        //StartCoroutine(TestFunction());
        stepManager.NextStep();
    }
}
