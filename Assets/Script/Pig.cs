using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float minSpeed = 5f;
    private SpriteRenderer render;
    public Sprite hunted;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision) //碰撞检测 
    {
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Destroy(gameObject);
        }
        else if (collision.relativeVelocity.magnitude < maxSpeed && collision.relativeVelocity.magnitude > minSpeed)
        {
            render.sprite = hunted;
        }
    }

    private void OnTriggerEnter(Collider other) //触发检测
    {
        
    }
}
