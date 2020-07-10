using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity;
using UnityEngine.EventSystems;

public class LeftHandCursor : MonoBehaviour
{
    
    public RectTransform m_mainCanvas;
    public Camera m_camera;
    public RectTransform m_image;
    //public GameObject cursorMesh;


    // Start is called before the first frame update
    void Start()
    {
        //start
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log( hand.Fingers[1].TipPosition.ToString());
        var hand = Hands.Left;
        //var indexPosition = hand.Fingers[1].TipPosition.ToVector3();
        var handposition = hand.PalmPosition.ToVector3();


        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_mainCanvas, handposition * 8000, m_camera, out anchoredPos);
        m_image.anchoredPosition = anchoredPos;
        //cursorMesh.transform.position = new Vector3(handposition.x * 900, handposition.y * 900, 100f);

    }


}
