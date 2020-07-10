using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    public GameObject[] steps;
    private int index;


    // Start is called before the first frame update
    void Start()
    {
        index = 0;

        if (!steps[index].activeSelf)
        {
            steps[index].SetActive(true);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject step in steps)
        {
            if (step != steps[index])
            {
                step.SetActive(false);
            }
            else
            {
                step.SetActive(true);
            }

        }

        
    }

    public void NextStep()
    {
        index += 1;

        Debug.Log("NEXT STEP");
       
    }

    public void PreviousStep()
    {
        index -= 1;
    }

    public void ResetStep()
    {
        index = 0;
    }

    public void GoToStep(int stepNumber)
    {
        index = stepNumber;
    }
    

    

}
