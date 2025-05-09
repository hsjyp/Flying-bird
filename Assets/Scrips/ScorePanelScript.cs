using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelScript : MonoBehaviour
{
    public List<Sprite> medles = new List<Sprite>();
    public void SetText(int score, int best) {
        //Debug.Log(best + " " + score);
        GameObject scoreText = transform.GetChild(0).gameObject;
        GameObject bestScore = transform.GetChild(1).gameObject;
        GameObject Medle = transform.GetChild(2).gameObject;
        if(best < score) {
            best = score;
            transform.GetChild(3).gameObject.SetActive(true);
        } else {
            transform.GetChild(3).gameObject.SetActive(false);
        }

        Sprite medle = medles[0];
        //Debug.Log(score);
        if(score >= 15) {
            medle = medles[2];
        }else if(score >= 10) {
            medle = medles[1];
        }else if(score >= 5) {
            medle = medles[0];
        } else {
            Medle.SetActive(false);
        }

        scoreText.GetComponent<Text>().text = score.ToString();
        bestScore.GetComponent<Text>().text = best.ToString();
        Medle.GetComponent<Image>().sprite = medle;


    }
}
