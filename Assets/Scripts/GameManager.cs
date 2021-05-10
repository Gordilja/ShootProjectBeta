using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject RetryPanel;
    public GameObject NextlvlPanel;
    public GameObject SlowMoPanel;
    private float waitTime = 0.5f;
    public bool move;
    public Text scoreTxt;
    public Text bulletTxt;
    public bool activePanel;
    public float slidePos;


    public void Start()
    {
        FindObjectOfType<GunFire>().bulletCount = 30;
        move = true;
    }
    private void Update()
    {
        
        if (slidePos <= 0)
        {
            return;
        }
        else if (slidePos > 0) 
        {
            slidePos = FindObjectOfType<MoveSlider>().value;
        }
        bulletTxt.text = "Ammo: " + FindObjectOfType<GunFire>().bulletCount.ToString();
    }

    private void Awake()
    {
        activePanel = true;
        StartPanel.SetActive(true);
        RetryPanel.SetActive(false);
        move = false;
        Time.timeScale = 0;
    }

    public void play()
    {
        Time.timeScale = 1;
        StartPanel.SetActive(false);
        RetryPanel.SetActive(false);
        activePanel = false;
    }

    public void retry() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<AudioManager>().idle.Pause();
    }

    public void levelClear() 
    {
        move = false;
        NextlvlPanel.SetActive(true);
        FindObjectOfType<SpawnManager>().maxSpawn *= 2;
        FindObjectOfType<AudioManager>().idle.Pause();
    }

    public void nextLevel() 
    {
        NextlvlPanel.SetActive(false);
        move = true;
        FindObjectOfType<MoveSlider>().sliderMove = true;
    }

    #region GameOver
    public void gameEnd()
    {
        move = false;
        FindObjectOfType<AudioManager>().idle.Pause();
        StartCoroutine(waitAnim());
    }
    IEnumerator waitAnim()
    {
        yield return new WaitForSeconds(waitTime);
        RetryPanel.SetActive(true);
        scoreTxt.text = FindObjectOfType<SaveData>().score.ToString() + " KILLS";
        DestroyAll();
    }

    void DestroyAll()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Zombie");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

    public void quitApp()
    {
        Application.Quit();
    }

    #endregion

    #region Test level changer
    private static SaveData saveData;
    public static SaveData SaveData
    {
        get
        {
            if (saveData == null)
            {
                Debug.LogError("SaveData does not exist in the scene.");
            }
            return saveData;
        }
        set
        {
            saveData = value;
        }
    }
    #endregion

    public void slowMotion() 
    {
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.2f * Time.timeScale;
        SlowMoPanel.SetActive(true);
        slidePos = FindObjectOfType<MoveSlider>().value;
    }

    public void outSLowM() 
    {
        FindObjectOfType<MoveSlider>().sliderMove = false;

        if (slidePos > 290 && slidePos < 340)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.2f * Time.timeScale;
            SlowMoPanel.SetActive(false);
            DestroyAll();
            FindObjectOfType<SaveData>().score = FindObjectOfType<SpawnManager>().maxSpawn;
            StartCoroutine(bombClear());

        }
        else if (slidePos < 290 || slidePos > 340) 
        {
            gameEnd();
        }
    }
    IEnumerator bombClear() 
    {
        yield return new WaitForSeconds(2);
        levelClear();
        slidePos = 0;
    }
}
