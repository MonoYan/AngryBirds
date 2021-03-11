using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public Animator anim;
    public GameObject button;

    private void Awake()
    {
        anim.GetComponent<Animator>();
    }

    public void Retry() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    /// <summary>
    /// 点击Pause按钮
    /// </summary>
    public void Pause() 
    {
        //播放动画
        anim.SetBool("isPause", true);
        button.SetActive(false);
        
    }
    /// <summary>
    /// 点击Home按钮
    /// </summary>
    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Resume() 
    {
        //播放动画
        Time.timeScale = 1;
        anim.SetBool("isPause", false);

    }

    /// <summary>
    /// Pause动画播放完调用
    /// </summary>
    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }
    /// <summary>
    /// Resume动画播放完调用
    /// </summary>
    public void ResumeAnimEnd()
    {
        button.SetActive(true);
    }
}
