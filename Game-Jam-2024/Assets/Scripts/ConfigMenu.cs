using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wilberforce;

public class ConfigMenu : MonoBehaviour
{
    Camera _mainCam;
    Colorblind colorblind;

    [SerializeField] GameObject configMenu;

    [SerializeField]Slider volumeSlider;

    static float volumeSliderValue = 1f;

    public Toggle[] daltonismToggles;
    static int daltonismValue;
    void Start()
    {

        AudioListener.volume = volumeSliderValue;
        _mainCam = Camera.main;
        colorblind = _mainCam.GetComponent<Colorblind>();
        colorblind.Type = daltonismValue;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) 
        { 
            OpenConfigMenu();
        }

        if(_mainCam ==null) 
        {
            _mainCam = Camera.main;
        }
    }

    public void ChangeType(int type) 
    {
        foreach(Toggle toggle in daltonismToggles) 
        {
            toggle.isOn = false;
        }
        colorblind.Type = type;
        daltonismValue = type;
    }

    public void OpenConfigMenu() 
    {
        configMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseConfigMenu() 
    { 
        Time.timeScale = 1.0f;
        configMenu.SetActive(false);

    }

    public void ChangeVolume() 
    { 
        AudioListener.volume = volumeSlider.value;
        volumeSliderValue = volumeSlider.value;
    }
}
