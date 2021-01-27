using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    private bool isCLick = false;
    public float maxDis = 1.25f;

    public Transform rightPos;
    public Transform leftPos;

    [HideInInspector] public SpringJoint2D sj;
    private Rigidbody2D rb;

    public LineRenderer lrRight;
    public LineRenderer lrLeft;
    public GameObject boom;

    private Trail myTrail;
    

    private void Awake()
    {
        sj = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        myTrail = GetComponent<Trail>();
    }

    private void OnMouseDown() //当鼠标按下
    {
        isCLick = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp() //当鼠标弹起
    {
        isCLick = false;
        rb.isKinematic = false;
        Invoke("Fly", 0.1f);
        //禁用划线组件，使得看起来更顺滑
        lrLeft.enabled = false;
        lrRight.enabled = false;
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

            Line();
        }

    }
    /// <summary>
    /// 飞行
    /// </summary>
    void Fly() //使SpriteJoint失活达到飞行功能
    {
        myTrail.StartTrail(); //飞行时播放特效
        sj.enabled = false;
        Invoke("Next", 3);
    }

    /// <summary>
    /// 皮筋儿绘制
    /// </summary>
    void Line() 
    {
        lrRight.enabled = true;
        lrRight.enabled = true;
        lrRight.SetPosition(0, rightPos.position);
        lrRight.SetPosition(1, transform.position);

        lrLeft.SetPosition(0, leftPos.position);
        lrLeft.SetPosition(1, transform.position);
    }

    /// <summary>
    /// 下一只小鸟飞出
    /// </summary>
    void Next() 
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager._instance.NextBirds();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myTrail.ClearTrail();//消除拖尾
    }
}
