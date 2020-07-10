using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchError : MonoBehaviour
{
    public GameObject touchErrorImage;

    private Color touchErrorImageColor;

    private float fadeSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        

        if (touchErrorImage.activeSelf == true)
        {
            touchErrorImage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        touchErrorImage.SetActive(true);

        fadeSpeed += 0.1f * 4;

        touchErrorImageColor = touchErrorImage.GetComponent<Image>().color;
        touchErrorImageColor.a = Mathf.Lerp(0f, 1f, fadeSpeed * Time.deltaTime);
        touchErrorImage.GetComponent<Image>().color = touchErrorImageColor;
    }



    private void OnTriggerExit(Collider other)
    {


        touchErrorImage.SetActive(false);
        fadeSpeed = 0f;


        
    }


    /*
    IEnumerator WaitAndFadeOut()
    {
        Debug.Log("called routine");

        yield return new WaitForSeconds(2);

        fadeSpeed -= 0.1f * 4;

        touchErrorImageColor = touchErrorImage.GetComponent<Image>().color;
        touchErrorImageColor.a = Mathf.Lerp(touchErrorImageColor.a, 0f, fadeSpeed * Time.deltaTime);
        touchErrorImage.GetComponent<Image>().color = touchErrorImageColor;

        fadeSpeed = 0f;
    }*/
}
