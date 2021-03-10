using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    private void Awake()
    {
        Instantiate(Resources.Load(PlayerPrefs.GetString("nowlevel")));
    }
}
