using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAttackHitbox : MonoBehaviour
{
  private int damage = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public void OnTriggerEnter2D(Collider2D hitCollider)
  {
    if (hitCollider.tag == "Enemy")
    {
      Vector2 knockbackDirection = transform.parent.transform.position - hitCollider.transform.position;
      knockbackDirection.Normalize();
      knockbackDirection = knockbackDirection * -1;

      hitCollider.GetComponent<Enemy>().Hurt(knockbackDirection, damage);
    }
  }

}
