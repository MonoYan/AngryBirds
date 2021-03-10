using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    public int startNum = 0;
    public bool isSelect = false;

    public GameObject locks, starts, panel, map;


    private void Start()
    {
        //存储每一关的星星数量，计算总和
        
        if (PlayerPrefs.GetInt("totalNum", 0) >= startNum)

        {
            isSelect = true;
        }

        if (isSelect)
        {
            locks.SetActive(false);
            starts.SetActive(true);

            //TODO:text显示
        }
    }
    /// <summary>
    /// MouseClick
    /// </summary>
    public void Selected() 
    {
        if (isSelect)
        {
            panel.SetActive(true);
            map.SetActive(false);
        }
    }

    public void ReturnSelect()
    {
        panel.SetActive(false);
        map.SetActive(true);
    }
}
