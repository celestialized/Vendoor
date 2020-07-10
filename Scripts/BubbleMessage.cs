using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleMessage : MonoBehaviour
{
    public GameObject bubbleMessage;
    public GameObject messageText;

    private Color bubbleMessageImageColor;
    private Color textColor;

    private float fadeSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bubbleMessage.transform.localScale = new Vector3(1, 1, 1);

        bubbleMessageImageColor = bubbleMessage.GetComponent<Image>().color;
        bubbleMessageImageColor.a = 0f;
        bubbleMessage.GetComponent<Image>().color = bubbleMessageImageColor;

        textColor = messageText.GetComponent<Text>().color;
        textColor.a = 0f;
        messageText.GetComponent<Text>().color = textColor;


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitAndFadeIn());

        
    }


    
    IEnumerator WaitAndFadeIn()
    {
       

        yield return new WaitForSeconds(2);

        fadeSpeed += 0.1f * 5;
        
        

        bubbleMessageImageColor = bubbleMessage.GetComponent<Image>().color;
        bubbleMessageImageColor.a = Mathf.Lerp(bubbleMessageImageColor.a, 1f, fadeSpeed * Time.deltaTime);
        bubbleMessage.GetComponent<Image>().color = bubbleMessageImageColor;

        textColor = messageText.GetComponent<Text>().color;
        textColor.a = Mathf.Lerp(textColor.a, 1f, fadeSpeed * Time.deltaTime); ;
        messageText.GetComponent<Text>().color = textColor;

        if (bubbleMessageImageColor.a == 1)
        {
            StartCoroutine(WaitAndFadeOut(5f));
        }


        

        
    }

    IEnumerator WaitAndFadeOut(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        bubbleMessage.SetActive(false);

       



        //bubbleMessage.SetActive(false);

        /*
        bubbleMessageImageColor = bubbleMessage.GetComponent<Image>().color;
        bubbleMessageImageColor.a = Mathf.Lerp(bubbleMessageImageColor.a, 0f, fadeSpeed * Time.deltaTime);
        bubbleMessage.GetComponent<Image>().color = bubbleMessageImageColor;

        textColor = messageText.GetComponent<Text>().color;
        textColor.a = Mathf.Lerp(textColor.a, 0f, fadeSpeed * Time.deltaTime); ;
        messageText.GetComponent<Text>().color = textColor;*/




    }
}
