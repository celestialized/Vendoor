using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadialKnob : MonoBehaviour
{
    public GameObject affector;

    public Image[] optionIcons;
    public TMP_Text toolName;
    private RectTransform rectTransform;
    public bool isRotating;




    public Image option1;
    public Image option2;
    public Image option3;
    public Image option4;
    public Image option5;


    float currentRotation = 0f;
    public int turningSpeed = 1;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();

        this.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.enabled==false)
        {
            isRotating = false;
        }
        else
        {
            isRotating = true;
        }
        if(isRotating == true)
        {
            RotateKnob();
        }
        
    }


    public void RotateKnob()
    {
        currentRotation = (rectTransform.rotation.z * 100) + Time.deltaTime;

        //Debug.Log(currentRotation);

        
        gameObject.transform.Rotate( new Vector3(0f, 0f, (-affector.transform.rotation.x + Time.deltaTime) * turningSpeed));

        if (currentRotation < 90.0f && currentRotation > 67.5f)
        {
            Debug.Log("Option 1");
            toolName.text = "3-D Rotate";
            option1.color = new Color(255, 150, 80);
            
        }
        else
        {
            option1.color = new Color(0.3019608f, 0.3019608f, 0.3019608f);
        }


        if (currentRotation < 67.5f && currentRotation > 22.5f)
        {
            Debug.Log("Option 2");
            toolName.text = "PANORAMIC";
            option2.color = new Color(255, 150, 80);

        }
        else
        {
            option2.color = new Color(0.3019608f, 0.3019608f, 0.3019608f);
        }


        if (currentRotation < 22.5f && currentRotation > -22.5f)
        {
            Debug.Log("Option 3");
            toolName.text = "MOVE OBJECT";
            option3.color = new Color(255, 150, 80);

        }
        else
        {
            option3.color = new Color(0.3019608f, 0.3019608f, 0.3019608f);
        }


        if (currentRotation < -22.5f && currentRotation > -67.5)
        {
            Debug.Log("Option 4");
            toolName.text = "360 VIEWER";
            option4.color = new Color(255, 150, 80);

        }
        else
        {
            option4.color = new Color(0.3019608f, 0.3019608f, 0.3019608f);
        }


        if (currentRotation < -67.5f && currentRotation > -90.0f)
        {
            Debug.Log("Option 5");
            toolName.text = "GYROSCOPE";
            option5.color = new Color(255, 150, 80);

        }
        else
        {
            option5.color = new Color(0.3019608f, 0.3019608f, 0.3019608f);
        }


    }
}
