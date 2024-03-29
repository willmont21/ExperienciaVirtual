﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D body;

    public float walkingSpeed;
    public float jumpSpeed;

    private void Awake()
    {
        trans = this.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { // x-axis movement
            body.velocity += jumpSpeed * Vector2.up;
        }

        { // x-axis movement
            var v = body.velocity;
            var speed = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += -walkingSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += walkingSpeed;
            }
            v.x = speed;
            body.velocity = v;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //var t = collision.gameObject.tag;
        var otherObject = collision.collider.gameObject;
        if (otherObject.tag == "Magnifier")
        {
            var scale = this.transform.localScale;

            if (scale.x >= 0.5) {
                scale.y /= 2;
                scale.x /= 2;
            }
            

            this.transform.localScale = scale;
            //otherObject.SetActive(false);
            //GameObject.Destroy(otherObject);
        }

        if (otherObject.tag == "Power")
        {
            var scale = this.transform.localScale;
            scale.y = 2;
            scale.x = 2;
            jumpSpeed += 4;

            this.transform.localScale = scale;
            otherObject.SetActive(false);
            //GameObject.Destroy(otherObject);
        }

        if (otherObject.tag == "Debuff")
        {
            var scale = this.transform.localScale;
            jumpSpeed =8;

            this.transform.localScale = scale;
            otherObject.SetActive(false);
            //GameObject.Destroy(otherObject);
        }

        if (otherObject.tag == "Move")
        {
            
            var scale = this.transform.localScale;
            jumpSpeed -= 4;

            this.transform.localScale = scale;
            otherObject.SetActive(false);
            //GameObject.Destroy(otherObject);
        }
    }

    
}
