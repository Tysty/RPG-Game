using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour {
    Vector3 ancor;
    string state;
    Animator anim;
    public GameObject rock;
    public GameObject shootorigin;
    NavMeshAgent nav;
    public GameObject player;
	// Use this for initialization
	void Start () {
        ancor = transform.position;
        state = "Move";
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(state == "Move")
        {
            move();
        }
        
	}
    void Changestate(string statename)
    {

    }
    void move()
    {
        Vector3 target = player.transform.position;
        nav.stoppingDistance = 4f;
        anim.SetFloat("moveP",nav.velocity.magnitude/nav.speed);
        if (Vector3.Distance(transform.position, target) > 7)
        {
            target = ancor;
            nav.stoppingDistance = 0f;
        }
        else
        {
            if (Random.Range(1, 100) < 2f)
            {
                Changestate("shoot");
            }
        }
        nav.SetDestination(target);
    }
    void ShootRock()
    {
        GameObject r = Instantiate(rock, shootorigin.transform.position, Quaternion.identity);
        Rigidbody rockbody = r.GetComponent<Rigidbody>();
        rockbody.AddForce(transform.forward * 500);
    }
}
