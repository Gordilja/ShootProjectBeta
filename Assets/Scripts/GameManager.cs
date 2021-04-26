using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject RetryPanel;
    public GameObject NextlvlPanel;
    private float waitTime = 0.5f;
    public int levelCount;
    public int levelReq;
    public bool move;

    public void Start()
    {   
        move = true;
    }

    private void Update()
    {
        levelReq = FindObjectOfType<SpawnManager>().maxSpawn;
        levelCount = FindObjectOfType<SaveData>().score - 1;
        if (levelCount == levelReq)
        {
            levelClear();
        }
       
    }

    private void Awake()
    {
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
       
    }

    public void retry() 
    {
        SceneManager.LoadScene("Game");
    }

    public void levelClear() 
    {
        StartCoroutine(finishedLevel());    
    }

    public void nextLevel() 
    {
        NextlvlPanel.SetActive(false);     
        move = true;
        //DestroyAll();
    }

    /*
    void DestroyAll()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Zombie");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }
    */

    #region GameOver
    public void gameEnd()
    {
        move = false;
        StartCoroutine(waitAnim());
    }
    IEnumerator waitAnim()
    {
        yield return new WaitForSeconds(waitTime);
        RetryPanel.SetActive(true);
    }
    IEnumerator finishedLevel()
    {
        NextlvlPanel.SetActive(true);
        move = false;
        yield return new WaitForSeconds(1);
        levelReq = levelReq + 5;
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
}
