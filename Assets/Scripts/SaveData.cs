using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveData : MonoBehaviour
{
    //public int level = 1;
    //public int achievedLevel = 1;
    public int score;
    public TextMeshProUGUI scoreNum;

    private void Awake()
    {
        GameManager.SaveData = this;
        score = 1;
        //achievedLevel = PlayerPrefs.GetInt("AchievedLevel", 1);
        //level = PlayerPrefs.GetInt("Level", 1);
    }

    public void scoreUp()
    {
        scoreNum.text = score.ToString();
        score++;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    /*
   public void LoadScore()
   {
       PlayerPrefs.GetInt("Score", score);

   }
   */
}
