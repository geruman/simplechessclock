using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowClockOrSettings : MonoBehaviour
{
    [SerializeField]
    ClockSettingsMono clockSettings;
    [SerializeField]
    ClockHandlerMono clockHandler;
    // Start is called before the first frame update
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    void Start()
    {
        clockSettings.gameObject.SetActive(true);
        clockHandler.gameObject.SetActive(false);
        clockSettings.settingsSelected+=SetSettings;
        clockHandler._gotoSettings+=GotoSettings;
    }
    void SetSettings(int minutes, int increments)
    {
        clockHandler.SetTimes(minutes, increments);
        clockSettings.gameObject.SetActive(false);
        clockHandler.gameObject.SetActive(true);
    }
    void GotoSettings()
    {
        clockSettings.gameObject.SetActive(true);
        clockHandler.gameObject.SetActive(false);
    }

    
}
