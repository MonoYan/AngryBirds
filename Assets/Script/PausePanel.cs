using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
