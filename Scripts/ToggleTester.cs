/*
 Authored by Gabriel Santa Maria
 Copyright 2020 Artificial Illusions
 www.artificialillusions.vision

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTester : MonoBehaviour
{

    public string toggleOnMessage;
    public string toggleOffMessage;

    public void ToggleOn()
    {
        print(gameObject.name + "Message: " + toggleOnMessage);
    }

    public void ToggleOff()
    {
        print(gameObject.name + "Message: " + toggleOnMessage);
    }


    private void OnTriggerEnter(Collider other)
    {
        print(other.name + " Entered " + gameObject.name + "trigger!");
    }

    private void OnTriggerExit(Collider other)
    {
        print(other.name + " Exited " + gameObject.name + "trigger!");
    }
}
