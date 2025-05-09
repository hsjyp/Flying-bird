using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject tut;
    public GameObject score;
    public GameObject main;

    public GameObject ScorePanle;
    public GameObject OverUI;

    public GameObject bird;
    public GameObject physicBird;
    public GameObject pipeController;
    public Text scoreText;

    bool IsReady = false;
    public void PlayBtnClick()
    {
        bird.GetComponent<anime>().ChangeState(true);
        Tools.Ins.HideUI(main);
        Tools.Ins.ShowUI(score);
        Tools.Ins.ShowUI(tut);
        //main.GetComponent<UIManager>().HideUI();
        //score.GetComponent<UIManager>().ShowUI();
        //tut.GetComponent<UIManager>().ShowUI();
        IsReady = true;
    }

    private void Start()
    {
        bird.GetComponent<anime>().ChangeState(false);
    }
    private void Update()
    {
        if (IsReady)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Tools.Ins.HideUI(tut);
                //tut.GetComponent<UIManager>().HideUI();
                bird.GetComponent<anime>().ChangeState(true, true);
                physicBird.GetComponent<birdFly>().Fly();
                pipeController.GetComponent<PipeController>().canCreatePipes = true;
                IsReady = false;
            }
        }
    }

    public void GameOver() {
        if (GameObject.Find("Backgrounds").GetComponent<backgroundController>().canMove == false) return;

        physicBird.GetComponent <birdFly>().enabled = false;
        pipeController.GetComponent<PipeController>().PipeStop();
        GameObject.Find("Backgrounds").GetComponent<backgroundController>().canMove = false;

        Tools.Ins.HideUI(score);
        Tools.Ins.ShowUI(OverUI);

        int newScore = int.Parse(scoreText.text);
        int bestScore = PlayerPrefs.GetInt("bestScore");
        //Debug.Log(newScore > bestScore);
        if(newScore > bestScore) {
            //Debug.Log("YES");
            PlayerPrefs.SetInt("bestScore", newScore);
        }
        ScorePanle.GetComponent<ScorePanelScript>().SetText(newScore, bestScore);
    }

    public void GetScore() {
        scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
    }

    public void Restart() {
        SceneManager.LoadScene("SampleScene");
    }
}
