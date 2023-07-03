using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class ClockHandlerMono : MonoBehaviour
{
    int _minutes;
    int _increments;
    float _timeLeftPlayerOne;
    float _timeLeftPlayerTwo;
    [SerializeField]
    TextMeshProUGUI _timeLeftPlayerOneTMP;
    [SerializeField]
    TextMeshProUGUI _timeLeftPlayerTwoTMP;
    [SerializeField]
    Button _timeLeftPlayerOneButton;
    [SerializeField]
    Button _timeLeftPlayerTwoButton;
    ClockState _currentState = ClockState.PAUSED;
    public Action _gotoSettings;
    public void SetTimes(int minutes, int increments)
    {
        _minutes = minutes;
        _increments = increments;
        _timeLeftPlayerOne = minutes*60;
        _timeLeftPlayerTwo = minutes*60;
        UpdateTimersText();
    }

    private void UpdateTimersText()
    {
        _timeLeftPlayerOneTMP.text = TimeSpan.FromSeconds(_timeLeftPlayerOne).Minutes.ToString("00")+":"+TimeSpan.FromSeconds(_timeLeftPlayerOne).Seconds.ToString("00")+":"+TimeSpan.FromSeconds(_timeLeftPlayerOne).Milliseconds.ToString("000");
        _timeLeftPlayerTwoTMP.text = TimeSpan.FromSeconds(_timeLeftPlayerTwo).Minutes.ToString("00")+":"+TimeSpan.FromSeconds(_timeLeftPlayerTwo).Seconds.ToString("00")+":"+TimeSpan.FromSeconds(_timeLeftPlayerTwo).Milliseconds.ToString("000"); ;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ExecuteState();

        CapPlayersTimeToMinimumZero();

        if (_timeLeftPlayerTwo==0||_timeLeftPlayerOne == 0)
        {
            DisableClockButtons();
        }
        UpdateTimersText();

    }

    private void DisableClockButtons()
    {
        _timeLeftPlayerOneButton.enabled = false;
        _timeLeftPlayerTwoButton.enabled = false;
    }

    private void CapPlayersTimeToMinimumZero()
    {
        if (_timeLeftPlayerOne<=0)
        {
            _timeLeftPlayerOne=0;
        }

        if (_timeLeftPlayerTwo<=0)
        {
            _timeLeftPlayerTwo=0;
        }
    }

    private void ExecuteState()
    {
        switch (_currentState)
        {
            case ClockState.PAUSED:
                _timeLeftPlayerOneButton.enabled = true;
                _timeLeftPlayerTwoButton.enabled = true;
                break;
            case ClockState.PLAYER_ONE_TURN:
                _timeLeftPlayerOne-= Time.deltaTime;
                break;
            case ClockState.PLAYER_TWO_TURN:
                _timeLeftPlayerTwo-= Time.deltaTime;
                break;
        }
    }

    public void ChangeState(int newStateId)
    {
        switch (newStateId)
        {
            case 1://player One finished turn
                if (_currentState!=ClockState.PAUSED)
                    _timeLeftPlayerOne += _increments;
                EnablePlayerTwoButton();
                _currentState = ClockState.PLAYER_TWO_TURN;
                break;
            case 2://player Two finished turn
                if (_currentState!=ClockState.PAUSED)
                    _timeLeftPlayerTwo += _increments;
                EnablePlayerOneButton();
                _currentState = ClockState.PLAYER_ONE_TURN;
                break;
        }
    }

    private void EnablePlayerOneButton()
    {
        _timeLeftPlayerOneButton.enabled = true;
        _timeLeftPlayerTwoButton.enabled = false;
    }

    private void EnablePlayerTwoButton()
    {
        _timeLeftPlayerOneButton.enabled = false;
        _timeLeftPlayerTwoButton.enabled = true;
    }

    public void GotoSettings()
    {
        _currentState = ClockState.PAUSED;
        _gotoSettings.Invoke();
    }
}
