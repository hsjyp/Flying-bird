using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //public CanvasGroup canvasGroup;
    public float duration = 1;
    public void HideUI()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        //Debug.Log("开始淡出");
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1f, 0f, time / duration);
            yield return null;
        }
        GetComponent<CanvasGroup>().alpha = 0f;
    }
    public void ShowUI() 
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        //Debug.Log("开始淡入");
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0f, 1f, time / duration);
            yield return null;
        }
        GetComponent<CanvasGroup>().alpha = 1f;
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
