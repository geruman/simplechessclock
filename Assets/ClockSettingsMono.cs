using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClockSettingsMono : MonoBehaviour
{
    public Action<int, int> settingsSelected; 
    public void SelectSettings(string clockValues)
    {
        settingsSelected.Invoke(int.Parse(clockValues.Split("|")[0]), int.Parse(clockValues.Split("|")[1]));
    }
}