using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {
	float damage = 1;
 //   void Start()
 //   {
 //       Destroy(gameObject, 5f);
 //   }

    void OnCollisionEnter(Collision collision)
    {
		GameObject other = collision.gameObject;
		health otherhealth = other.GetComponent<health>();
		if (otherhealth) {
			otherhealth.takeDamage (2);
		}
        Destroy(gameObject);
    }
}
