using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Text PointsTxt, highPointsTxt, Score;
    public static int Points, highPointsCounter;
    public GameObject ResultObj;

    public bool CanPlay = true;

    private void Awake() {
        instance = this;
        if (PlayerPrefs.HasKey("SavePoints")) {
            highPointsCounter = PlayerPrefs.GetInt("SavePoints");
        }
    }

    void Start() {
        Points = 0;
        ResultObj.SetActive(false);
    }

    public void ShowResult() {
        CanPlay = false;
        Score.text = "Score: " + Points;
        ResultObj.SetActive(true);
    }

    void Update() {
        PointsTxt.text = "Points: " + Points;
        highPointsTxt.text = "HighPoints: " + highPointsCounter;
    }

    public void AddPoints() {
        Points++;
        HighPoint();
    }
    public void HighPoint() { 
        if (Points > highPointsCounter)
        {
            highPointsCounter = Points;
            PlayerPrefs.SetInt("SavePoints", highPointsCounter);
        }
    }
}
