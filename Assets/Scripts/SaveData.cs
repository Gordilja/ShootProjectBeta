using UnityEngine;
using TMPro;

public class SaveData : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreNum;
    public int counterTag;

    private void Awake()
    {
        GameManager.SaveData = this;
        score = 0;
    }

    private void Update()
    {
        scoreNum.text = score.ToString();
    }

    public void scoreUp()
    {
        scoreNum.text = score.ToString();
        score++;
        if (counterTag < 7)
        {
            counterTag++;
        }
        else
        {
            counterTag = 0;
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
