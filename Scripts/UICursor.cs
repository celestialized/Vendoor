using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity;
using UnityEngine.EventSystems;
//using Leap;

public class UICursor : MonoBehaviour
{
    public PinchControl2D pinchController;

    public Sprite handCursor_Grabbing;
    public Sprite handCursor_Neutral;

    protected Image m_CursorImage;
    



    

    // Start is called before the first frame update
    void Start()
    {
        m_CursorImage = GetComponent<Image>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(pinchController.isPinching == true)
        {
            m_CursorImage.sprite = handCursor_Grabbing;
        }
        else
        {
            m_CursorImage.sprite = handCursor_Neutral;
        }

        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Button button = collider.GetComponent<Button>();

        //Debug.Log("Cursor Entered " + button.name);

        Image buttonImg = button.image;

        //buttonImg.color = new Color32(255, 255, 255, 255);

        

        if (pinchController.isPinching == true)
        {
            //Debug.LogFormat("<b> pinched on </b>" + button.name);
            button.onClick.Invoke();
            pinchController.isPinching = false;
        }

        




    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Button button = collider.GetComponent<Button>();


        Image buttonImg = button.image;

        //buttonImg.color = new Color32(255, 255, 255, 100);
    }




}
