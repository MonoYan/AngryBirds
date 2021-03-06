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
    /// ���Pause��ť
    /// </summary>
    public void Pause() 
    {
        //���Ŷ���
        anim.SetBool("isPause", true);
        button.SetActive(false);
        
    }
    /// <summary>
    /// ���Home��ť
    /// </summary>
    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Resume() 
    {
        //���Ŷ���
        Time.timeScale = 1;
        anim.SetBool("isPause", false);

    }

    /// <summary>
    /// Pause�������������
    /// </summary>
    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }
    /// <summary>
    /// Resume�������������
    /// </summary>
    public void ResumeAnimEnd()
    {
        button.SetActive(true);
    }
}
