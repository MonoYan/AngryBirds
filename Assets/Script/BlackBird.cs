using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Birds
{
    public List<Pig> blocks = new List<Pig>();
    /// <summary>
    /// 进入触发区域
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            blocks.Add(collision.gameObject.GetComponent<Pig>());
        }
    }
    /// <summary>
    /// 离开触发区域
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            blocks.Remove(collision.gameObject.GetComponent<Pig>());
        }
    }

    public override void ShowSkill()
    {
        base.ShowSkill();
        System.Console.WriteLine("Test");
        if (blocks.Count > 0 && blocks != null)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].DeadEffect();
            }
        }
        onClear();
    }

    void onClear() 
    {
        rb.velocity = Vector3.zero;
        Instantiate(boom,transform.position,Quaternion.identity);
        render.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false; //优先获取第一个
        myTrail.ClearTrail();
    }

    protected override void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        GameManager._instance.NextBirds();
    }
}
