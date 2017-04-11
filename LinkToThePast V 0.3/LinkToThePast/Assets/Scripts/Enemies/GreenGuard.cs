using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGuard : Enemy
{

  public Controller2D controller;
  private Animator anim;
  public Vector2 velocity;
  public Enemy enemyScript;
  private Vector2 knockbackDirection;

  // Use this for initialization
  void Start()
  {
    anim = GetComponent<Animator>();
    controller = GetComponent<Controller2D>();

  }

  // Update is called once per frame
  void Update()
  {
    if (hurtTimer > 0)
    {
      hurtTimer -= Time.deltaTime;
      velocity = knockbackDirection * 180;
    }
    if (hurtTimer <= 0)
    {
      velocity = Vector2.zero;
    }


    controller.Move(velocity * Time.deltaTime);
  }

  
  public override void Hurt(Vector2 direction, int damage)
  {
    base.Hurt(direction, damage);
    knockbackDirection = direction;
    hurtTimer = 0.15f;
    anim.Play("Hurt");

  }

  private void LateUpdate()
  {
    if (velocity == Vector2.zero)
    {
      transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), transform.position.z);
    }
  }
}
