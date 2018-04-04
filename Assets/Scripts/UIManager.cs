﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{

    public Dropdown microphone;
    public Slider sensitivitySlider, thresholdSlider;
    public GameObject settingsPanel;
    public GameObject openButton;

    private bool panelActive = false;

    // Use this for initialization
    void Start()
    {
        microphone.value = PlayerPrefsManager.GetMicrophone();
        sensitivitySlider.value = PlayerPrefsManager.GetSensitivity();
        thresholdSlider.value = PlayerPrefsManager.GetThreshold();
        settingsPanel.SetActive(false);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMicrophone(microphone.value);
        PlayerPrefsManager.SetSensitivity(sensitivitySlider.value);
        PlayerPrefsManager.SetThreshold(thresholdSlider.value);

        panelActive = !panelActive;
        settingsPanel.SetActive(false);
    }

    public void SetDefaults()
    {
        microphone.value = 0;
        sensitivitySlider.value = 100f;
        thresholdSlider.value = 0.001f;
    }

    public void OpenSettings()
    {
        panelActive = !panelActive;
        settingsPanel.SetActive(true);
    }

    public void TogglePanel()
    {
        if (!panelActive)
        {
            OpenSettings();
        }
        else
        {
            SaveAndExit();
        }
    }
}