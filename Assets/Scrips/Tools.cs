using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools 
{
    static Tools instance = null;

    public static Tools Ins {
        get {
            if(instance == null) {
                instance = new Tools();
            }
            return instance;
        }
    }


    public void ShowUI(GameObject uiObj) {
        uiObj.SetActive(true);
        uiObj.GetComponent<CanvasGroup>().alpha = 0f;
        uiObj.GetComponent<UIManager>().ShowUI();
    }
    public void HideUI(GameObject uiObj) {
        uiObj.GetComponent<UIManager>().HideUI();
    }
}
