﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPrefab : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 0.7f);
	}
	
	// Update is called once per frame
	void Update ()
	{
    transform.position = transform.parent.transform.position;
  }
}
