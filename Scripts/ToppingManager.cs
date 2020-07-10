using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToppingManager : MonoBehaviour
{
    public Sprite currentChoiceImage;
    private Sprite originalImage;

    public GameObject[] toppings;
    private GameObject currentFlavor;
    private GameObject otherFlavor;

    public float toppingCounter = 0;

    public StepManager m_stepManager;


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("TOPPING COUNTER: " + toppingCounter);

        /*if (toppingCounter == 2)
        {
            m_stepManager.NextStep();
        }*/
    }

    public void ToppingChecker(GameObject toppingChoice, bool isCurrent)
    {



        foreach (GameObject topping in toppings)
        {

            //originalImage = flavor.GetComponent<Image>().sprite;

            if (topping.name != toppingChoice.name)
            {
                
                //Debug.Log("NOT the current Topping");
                topping.SetActive(true);

            }
            else
            {

                //Debug.Log("Current Topping");
                


            }
        }
    }



}
