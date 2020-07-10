using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class SequenceController : MonoBehaviour
{
    [Header("Image Sequence")]

    public Sprite[] imageSequence;
    
    private Renderer m_Renderer;
    public Texture textureIndex; 

    [Header("Sequence Controls")]
    public bool loopSequence;
    public Slider slider;


    [Header("Sequence Effects")]
    public bool fadeIn = false;
    public bool fadeOut = false;
    public float fadeInSeconds = 0;


    void Start()
    {
        m_Renderer = gameObject.GetComponent<Renderer>();

        m_Renderer.material.SetTexture("_AlbedoTexture", imageSequence[0].texture);
        m_Renderer.material.SetFloat("_Opacity", 0);


    }


    public void PlaySequence()
    {
        if (fadeIn == true)
        {
            FadeIn();
        }
        

        StopCoroutine("SequenceProcessor");
        StartCoroutine("SequenceProcessor");

        StopCoroutine("TextureSequenceProcessor");
        StartCoroutine("TextureSequenceProcessor");

        FadeOut();
    }

    void Update()
    {
        SequenceSliderController();
        
    }

    // Process a Sprite Sequence.
    IEnumerator SequenceProcessor()
    {
        for (int i = 0; i < imageSequence.Length; i++)
        {
            //For UI Sprite

            GetComponent<Image>().sprite = imageSequence[i]; //loop image sequence



            yield return null;

        }


    }

    // Process a Mesh Texture Map Sequence.
    IEnumerator TextureSequenceProcessor()
    {
        for (int i = 0; i < imageSequence.Length; i++)
        {
            

            textureIndex = imageSequence[i].texture;

            m_Renderer.material.SetTexture("_AlbedoTexture", textureIndex);


            yield return null;

        }
        

    }

    void Loop(int i)
    {
        
    }

    //Use a UI Slider to control the Sequence
    void SequenceSliderController() 
    {
        int min = 0;

        slider.minValue = min;
        slider.maxValue = imageSequence.Length;

        GetComponent<Image>().sprite = imageSequence[(int)slider.value];
    }

    void FadeIn()
    {

        for (float t = 0.0f; t < fadeInSeconds; t += Time.deltaTime / fadeInSeconds)
        {
            m_Renderer.material.SetFloat("_Opacity", fadeInSeconds);
        }


    }
    void FadeOut()
    {

        for (float t = 1.0f; t == fadeInSeconds; t -= Time.deltaTime / fadeInSeconds)
        {
            m_Renderer.material.SetFloat("_Opacity", fadeInSeconds);
        }


    }



}
