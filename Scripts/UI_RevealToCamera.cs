using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UI_RevealToCamera : MonoBehaviour
{
    public GameObject objectToLookAt;
    public GameObject gameObjectToOccludeFrom;


    public TextMeshPro infographic_label;
    private bool infographic_lable_active;
    Animation infograhic_label_animation;
    Animator infographic_label_animator;
    

    public LineRenderer laserLineRenderer;

   

    Renderer rend;


    public Vector3 direction;
    public RaycastHit hit;
    public float maxDistance = 10;
    LayerMask layerMask;


    //THIS SCRIPT MAKES USER INTERFACE ELMENTS REVEAL THEMSELVES TO USER DEPENDING ON ORIENTATION OF MODEL.
    //THIS SCRIPT IS INTENDED FOR WORLD-SPACE UI CANVAS USED AS INDICATORS.
    //UI ELEMENTS HIDES ITSELF WHEN POSITIONED BEHIND OBSERVABLE MODEL.

    

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    
        infographic_label_animator = infographic_label.GetComponent<Animator>();
        infographic_lable_active = false;

       
        
    }

    // Update is called once per frame
    void Update()
    {

       

        gameObject.transform.LookAt(objectToLookAt.transform.position);

        
        Debug.DrawRay(transform.position, transform.forward * maxDistance , Color.yellow);

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "TestingModel")
            {
                //Debug.Log("hit testing model");
                print(hit.transform.name);

                rend.enabled = false;

              

                infographic_label_animator.Play("Scale Out");

            }
            else
            {
                rend.enabled = true;

                infographic_label_animator.Play("Scale");
                


            }
            
            
        }

        laserLineRenderer.SetPosition(0, gameObject.transform.position);
        laserLineRenderer.SetPosition(1, objectToLookAt.transform.position);
        
    }

   
   
}
