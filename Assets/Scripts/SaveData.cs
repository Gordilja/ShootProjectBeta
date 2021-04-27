using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveData : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreNum;

    private void Awake()
    {
        GameManager.SaveData = this;
        if(score < 1)
            score = 1;
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
