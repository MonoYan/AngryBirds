using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Birds> birds;
    public List<Pig> pigs;

    public GameObject[] stars;
    public static GameManager _instance;
    private Vector3 originPos; //初始化的位置

    public GameObject PausePanel;
    public GameObject win;
    public GameObject lose;

    private int startsNum = 0;

    private int totalLevelNum = 10;
    private void Awake()
    {
        _instance = this;
        if (birds.Count > 0) { originPos = birds[0].transform.position; }
        
    }

    private void Start()
    {
        Initialized();
    }
    /// <summary>
    ///   初始化
    /// </summary>
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sj.enabled = true;
            }

            else
            {
                birds[i].enabled = false;
                birds[i].sj.enabled = false;
            }
        }
    }
    /// <summary>
    ///  游戏逻辑
    /// </summary>
    public void NextBirds() 
    {
        if (pigs.Count > 0)
        {
            if (birds.Count > 0)
            {
                // 下一只小鸟儿
                Initialized();
            }
            else
            {
                PausePanel.SetActive(false);
                lose.SetActive(true);
            }
        }
        else
        {
            PausePanel.SetActive(false);
            win.SetActive(true);
        }
    }

    public void ShowStarts() 
    {
        StartCoroutine("Show");
    }

    IEnumerator Show() {
        for (; startsNum < birds.Count + 1; startsNum++)
        {
            if (startsNum >= stars.Length)
            {
                break;
            }
            yield return new WaitForSeconds(0.2f);
            stars[startsNum].SetActive(true);
        }
    }

    public void Replay() 
    {
        SceneManager. LoadScene(2);
        SaveStartData();
    }

    public void Home() {
        SaveStartData();
        SceneManager.LoadScene(1);
    }

    public void SaveStartData() 
    {
        if (startsNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowlevel")))
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("nowlevel"), startsNum);
        }
        //储存星星的个数
        int sum = 0;
        for (int i = 1; i < totalLevelNum; i++)
        {
            sum += PlayerPrefs.GetInt(PlayerPrefs.GetString("level") + i.ToString());
        }

        PlayerPrefs.SetInt("totalNum", sum);
    }
}
