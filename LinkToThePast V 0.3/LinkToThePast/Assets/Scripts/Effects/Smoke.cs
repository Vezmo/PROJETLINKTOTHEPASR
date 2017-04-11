using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

	public float timer = 0.01f;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.enabled = true;
	}
	
	// Update is called once per frame
	void Update () { 
		timer -= Time.deltaTime;
		if (timer < 0){
			Destroy (gameObject);
		}
	}
}