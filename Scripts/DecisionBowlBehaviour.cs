using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionBowlBehaviour : MonoBehaviour
{
    public GameObject decidedBowlImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "DecisionDrop")
        {
            decidedBowlImage.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "DecisionDrop")
        {
            decidedBowlImage.SetActive(false);

        }
    }
}
