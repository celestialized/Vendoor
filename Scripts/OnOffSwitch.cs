/*
 Authored by Gabriel Santa Maria
 Copyright 2020 Artificial Illusions
 www.artificialillusions.vision

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffSwitch : MonoBehaviour
{

  public void ToggleSwitch()
    {
        gameObject.SetActive(!gameObject.activeSelf);

    }
}
