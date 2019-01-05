using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour {
    public Slider healthbar;
    public float maxhealth;
    float current;
	// Use this for initialization
	void Start () {
        current = maxhealth;
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void takeDamage(float amount)
    {
        current -= amount;
        healthbar.value = current / maxhealth;
    }
}
