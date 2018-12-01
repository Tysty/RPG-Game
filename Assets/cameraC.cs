using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraC : MonoBehaviour {
    float ddistance = 3;
    public GameObject target;
    public float pitch = 0f;
    float pitchmin = -40;
    float pitchmax = 60;
    public float yaw = 0f;
    public float roll = 0f;
    public float sensitive = 15f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Mathf.Clamp(pitch, pitchmin, pitchmax);
        pitch -= sensitive*Input.GetAxis("Mouse Y");
        yaw += sensitive * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(pitch, yaw, roll);
        transform.position = target.transform.position - ddistance * transform.forward+Vector3.up*1.5f;
	}
}
