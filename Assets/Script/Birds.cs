using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    private bool isCLick = false;
    public Transform rightPos;
    public float maxDis = 1.25f;

    private bool onBirds = false;
    private bool noClick = false;
    private SpringJoint2D sj;
    private Rigidbody2D rb;

    private void Awake()
    {
        sj = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown() //当鼠标按下
    {
        isCLick = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp() //当鼠标弹起
    {
        isCLick = false;
        noClick = true;
        rb.isKinematic = false;
        Invoke("Fly", 0.1f);

    }

    private void Update()
    {
        if (isCLick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); //坐标系转换
            transform.position += new Vector3(0,0,1);

            if (Vector3.Distance(transform.position, rightPos.position) > maxDis)  //进行位置限定
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;  //单位化向量
                pos *= maxDis; //最大长度向量
                transform.position = pos + rightPos.position;

            }

            onBirds = true;
        }

    }

    void Fly() 
    {
        sj.enabled = false;
    }
}
