using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public GameObject scrollBar;
    float scrollPos = 0;
    float[] index;

    bool isScrollNextActive;
    bool isScrollPreviousActive;

    // Start is called before the first frame update
    void Start()
    {
        isScrollNextActive = false;
        isScrollPreviousActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isScrollNextActive == true)
        {
            ScrollNext();
           
        }
        else
        {
            StopScroll();
        }

        if (isScrollPreviousActive == true)
        {
            ScrollPrevious();
        }
        else
        {
            StopScroll();
        }*/

        
        
    }

    public void ScrollNext()
    {
        isScrollNextActive = true;

        Debug.Log("Scroll Next Is called");

        index = new float[transform.childCount];
        float distance = 1f / (index.Length - 1f); //0.25f
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = distance * i;
        }

        scrollPos = scrollBar.GetComponent<Scrollbar>().value; //scrollPos == scroll value. e.g: 0.25f on option 1

        for (int i = 0; i < index.Length; i++) //iterate through options
        {
            if (scrollPos < index[i] + (distance / 2) && scrollPos > index[i] - (distance / 2))
            // if the position of element at scroll is less than the index position plus half the distance (0.125)...
            //...and the position of element at scroll is greater than the index position minus half the distance...
            {
                scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, index[i], 0.1f);
            }
        }

        for (int i = 0; i < index.Length; i++)
        {
            if (scrollPos < index[i] + (distance / 2) && scrollPos > index[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int j = 0; j < index.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }

    public void ScrollPrevious()
    {
        isScrollPreviousActive = true;

        Debug.Log("Scroll Previous Is called");

        index = new float[transform.childCount];
        float distance = 1f / (index.Length - 1f); //0.25f
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = distance * i;
        }

        scrollPos = scrollBar.GetComponent<Scrollbar>().value; //scrollPos == scroll value. e.g: 0.25f on option 1

        for (int i = 0; i < index.Length; i++) //iterate through options
        {
            if (scrollPos > index[i] + (distance / 2) && scrollPos > index[i] - (distance / 2))
            // if the position of element at scroll is less than the index position plus half the distance (0.125)...
            //...and the position of element at scroll is greater than the index position minus half the distance...
            {
                scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, index[i], 0.1f);
            }
        }

        for (int i = 0; i < index.Length; i++)
        {
            if (scrollPos < index[i] + (distance / 2) && scrollPos > index[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int j = 0; j < index.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }

    public void StopScroll()
    {
        isScrollNextActive = false;
        isScrollPreviousActive = false;
    }

    /*void Scroll()
    {
        index = new float[transform.childCount];
        float distance = 1f / (index.Length - 1f); //0.25f
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollBar.GetComponent<Scrollbar>().value; //scrollPos == scroll value. e.g: 0.25f on option 1
        }
        else
        {
            for (int i = 0; i < index.Length; i++) //iterate through options
            {
                if (scrollPos < index[i] + (distance / 2) && scrollPos > index[i] - (distance / 2)) 
                    // if the position of element at scroll is less than the index position plus half the distance (0.125)...
                    //...and the position of element at scroll is greater than the index position minus half the distance...
                {
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, index[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < index.Length; i++)
        {
            if (scrollPos < index[i] + (distance / 2) && scrollPos > index[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int j = 0; j < index.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    
    }   */
}
