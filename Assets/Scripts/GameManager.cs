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
    float valueX;
    int minValue = 32;
    int maxValue = 68;
    public bool stopTime;
    public List<GameObject> zombies;


    public void Start()
    {
        zombies = new List<GameObject>();
        FindObjectOfType<GunFire>().bulletCount = 30;
        stopTime = false;
        move = true;
        FindObjectOfType<SpawnManager>().counterSpawn = 0;
    }

    private void Update()
    {
        zombies.Add(GameObject.FindGameObjectWithTag("Zombie " + 0));
        zombies.Add(GameObject.FindGameObjectWithTag("Zombie " + 1));
        zombies.Add(GameObject.FindGameObjectWithTag("Zombie " + 2));
        zombies.Add(GameObject.FindGameObjectWithTag("Zombie " + 3));
        zombies.Add(GameObject.FindGameObjectWithTag("Zombie " + 4));
        zombies.Add(GameObject.FindGameObjectWithTag("Zombie " + 5));
        zombies.Add(GameObject.FindGameObjectWithTag("Zombie " + 6));
        zombies.Add(GameObject.FindGameObjectWithTag("Zombie " + 7));

        valueX = FindObjectOfType<MoveSlider>().sliderInstance.value;
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
        FindObjectOfType<SaveData>().counterTag = 0;
        FindObjectOfType<SpawnManager>().counterSpawn = 0;
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
        FindObjectOfType<SaveData>().counterTag = 0;
        FindObjectOfType<SpawnManager>().counterSpawn = 0;
    }

    #region GameOver
    public void gameEnd()
    {
        move = false;
        FindObjectOfType<AudioManager>().idle.Pause();
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.2f * Time.timeScale;
        SlowMoPanel.SetActive(false);
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
        //GameObject[] enemies = zombies;
        for (int i = 0; i < zombies.Count; i++)
        {
            Destroy(zombies[i]);
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
        activePanel = true;
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.2f * Time.timeScale;
        SlowMoPanel.SetActive(true);
        stopTime = true;
    }

    public void outSLowM() 
    {
        stopTime = false;
        activePanel = false;

        if (valueX > minValue && valueX < maxValue)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.2f * Time.timeScale;
            SlowMoPanel.SetActive(false);
            DestroyAll();
            FindObjectOfType<SaveData>().score = FindObjectOfType<SpawnManager>().maxSpawn;
            FindObjectOfType<MoveSlider>().speed *= 2;
            StartCoroutine(bombClear());
        }
        else if (valueX < minValue || valueX > maxValue) 
        {
            gameEnd();
        }
    }
    IEnumerator bombClear() 
    {
        yield return new WaitForSeconds(2);
        levelClear();
    }
}
