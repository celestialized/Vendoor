using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableObjects : MonoBehaviour
{
    public GameObject[] objectsToEnable;
    public GameObject[] objectsToDisable;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject GO in objectsToEnable)
        {
            GO.SetActive(true);
        }
        foreach (GameObject GO in objectsToDisable)
        {
            GO.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
