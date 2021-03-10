using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour
{
    public int startNum = 0;
    public bool isSelect = false;

    public GameObject locks, starts, panel, map;
    public Text startsText;

    public int startSNum = 1;
    public int endNum = 3;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
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
            int count = 0;
            for (int i = startSNum; i < endNum; i++)
            {
                count += PlayerPrefs.GetInt("Level" + i.ToString(),0);
            }
            startsText.text = count.ToString() + "/9";
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
