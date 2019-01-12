using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour {
	Vector3 checkpoint;
    public Slider healthbar;
    public float maxhealth;
	Animator anim;
    float current;
	// Use this for initialization
	void Start () {
		checkpoint = transform.position;
        current = maxhealth;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void takeDamage(float amount)
    {
        current -= amount;
        healthbar.value = current / maxhealth;
		if(current <= 0){
			SendMessage ("OnDeath");
		}
    }
	public void Reset(){
		current = maxhealth;
		healthbar.value = current;
	}
	void OnDeath(){
		anim.SetTrigger ("Break");
	}
}
