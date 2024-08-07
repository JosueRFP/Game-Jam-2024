using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wilberforce;

public class ConfigMenu : MonoBehaviour
{
    Camera _mainCam;
    Colorblind colorblind;

    public Toggle[] daltonismToggles;
    void Start()
    {
        _mainCam = Camera.main;
        colorblind = _mainCam.GetComponent<Colorblind>();
    }

    public void ChangeType(int type) 
    {
        foreach(Toggle toggle in daltonismToggles) 
        {
            toggle.isOn = false;
        }
        colorblind.Type = type;
    }

    public void CloseConfigMenu() 
    { 
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);

    }

}
