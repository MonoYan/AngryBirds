using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Birds> birds;
    public List<Pig> pigs;
    public GameObject[] stars;
    public static GameManager _instance;
    private Vector3 originPos; //初始化的位置

    public GameObject win;
    public GameObject lose;

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
                lose.SetActive(true);
            }
        }
        else
        {
            win.SetActive(true);
        }
    }

    public void ShowStarts() 
    {
        StartCoroutine("Show");
    }

    IEnumerator Show() {
        for (int i = 0; i < birds.Count ; i++)
        {
            yield return new WaitForSeconds(0.2f);
            stars[i].SetActive(true);
        }
    }
}
