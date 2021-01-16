using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    private bool isCLick = false;
    private bool onBirds = false;
    private bool noClick = false;
    public SpringJoint2D springJoint2D;


    private void OnMouseDown() //当鼠标按下
    {
        isCLick = true;    
    }

    private void OnMouseUp() //当鼠标弹起
    {
        isCLick = false;
        noClick = true;
    }

    private void Update()
    {
        if (isCLick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); //坐标系转换
            transform.position += new Vector3(0,0,1);
            onBirds = true;
        }

        if (noClick && onBirds) {
            Destroy(springJoint2D);
        }

    }
}
