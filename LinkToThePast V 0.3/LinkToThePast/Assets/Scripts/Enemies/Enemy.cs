using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public int hp;
  protected float hurtTimer;
  public GameObject deathPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
  {
		
	}

  public virtual void Hurt(Vector2 direction, int damage)
  {
    hp -= damage;
    

    if (hp <= 0)
    {
      Instantiate(deathPrefab, transform);
      Destroy(gameObject,0.55f);
    }
  }



}
