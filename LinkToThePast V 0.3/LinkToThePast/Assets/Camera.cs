using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Link")
        {
            transform.position = new Vector3(Mathf.RoundToInt(target.transform.position.x), Mathf.RoundToInt(target.transform.position.y), transform.position.z);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
