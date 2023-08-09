using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float minSpeed=5;
    public float maxSpeed=10;
    private SpriteRenderer render;
    public Sprite hurt;
    public GameObject boom;
    private void Awake() {
        render=GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag=="Bird"&& collision.relativeVelocity.magnitude>maxSpeed)
        {
            Dead();
        }
        else if (collision.relativeVelocity.magnitude>minSpeed && collision.relativeVelocity.magnitude<=maxSpeed)
        {
            render.sprite=hurt;
        }
        
    }
    void Dead(){
        Destroy(gameObject);
        Instantiate(boom,transform.position,Quaternion.identity);


    }



}
