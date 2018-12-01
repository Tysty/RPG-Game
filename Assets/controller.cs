﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {
    CharacterController cc;
    public string state = "Movement";
    public float jumpVel = 0;
    public float jumpH = 16;
    public float gravity = 0f;
    Animator anim;
    public float movespeed = 4;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (state == "Movement")
        {
            movement();
            swing();
        }
        if (state == "Jump")
        {
            jump();
            movement();
        }
    }
    void movement()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0, z).normalized;
        Vector3 velocity = direction*movespeed*Time.deltaTime;
        float percentspeed = velocity.magnitude / (movespeed * Time.deltaTime);
        anim.SetFloat("movePercent",percentspeed);
        if (velocity.magnitude > 0)
        {
            float yAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.localEulerAngles = new Vector3(0, yAngle, 0);
        }
        if (cc.isGrounded && state == "Jump")
        {
            gravity = 0f;
            changestate("Movement");
            jumpVel = 0;
        }
        else
        {
            gravity += 0.25f;
            gravity = Mathf.Clamp(gravity, 1f, 10f);
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            jumpVel = jumpH;
            changestate("Jump");
        }
        Vector3 gravityVector = -Vector3.up * gravity * Time.deltaTime;
        Vector3 jumpVector = Vector3.up * jumpVel * Time.deltaTime;
        cc.Move(velocity + gravityVector+jumpVector);
    }
    void changestate(string StateName)
    {
        state = StateName;
        anim.SetTrigger(StateName);
    }
    void jump() {
        
        if (jumpVel < 0){
            return;
            
            }
        jumpVel -= 0.25f;
    }
    void swing()
    {
        if (Input.GetMouseButtonDown(0)) {
            changestate("Swing");
        }
    }
    void ReturnTMove() {
        changestate("Movement");
    }
}