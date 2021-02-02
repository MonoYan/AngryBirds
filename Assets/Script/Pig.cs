using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float minSpeed = 5f;
    public bool isPig = false;

    private SpriteRenderer render;
    public Sprite hunted;
    public GameObject boom;
    public GameObject score;

    public AudioClip dead, hurtAudio, birdCollision;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision) //碰撞检测 
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioPlay(birdCollision);
        }

        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            DeadEffect();
        }
        else if (collision.relativeVelocity.magnitude < maxSpeed && collision.relativeVelocity.magnitude > minSpeed)
        {
            render.sprite = hunted; //sprite 转换
            AudioPlay(hurtAudio);
        }
    }

    public void DeadEffect() {
        if (isPig)
        {
            GameManager._instance.pigs.Remove(this);
        }
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity); //boom效果

        GameObject scores =  Instantiate(score, transform.position + new Vector3(0,1.3f,0), Quaternion.identity); //得分
        Destroy(scores, 0.4f);

        AudioPlay(dead);
        
    }
    //private void OnTriggerEnter(Collider other) //触发检测 {}

    public void AudioPlay(AudioClip clip) 
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
