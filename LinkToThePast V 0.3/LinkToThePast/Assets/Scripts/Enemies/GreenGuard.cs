using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class GreenGuard : Framework
{

  public Vector2 velocity;
  public Vector2 knockBackDirection;
  private int knockBackSpeed = 250;
  public Controller2D controller;
  public int moveSpeed = 95;
  public float hurtTimer;
  private int health;
  public GameObject deathPrefab;
  public bool isDying;
  GameObject link;
  public Orientation currentOrientation;
  private Orientation startingOrientation = Orientation.Down;
  public bool isOrientedDown;
  public bool isOrientedLeft;
  public bool isOrientedRight;
  public bool isOrientedUp;
  public EnemyBaseState state;
  public Animator anim;
  public SpriteRenderer renderer;
  private bool canFlip;
  public bool isAttacking = false;
  public bool isBufferingCharge = false;

  protected override void OnStart()
  {
    currentOrientation = Orientation.Down;
    anim = GetComponent<Animator>();
    renderer = GetComponent<SpriteRenderer>();
    controller = GetComponent<Controller2D>();

    health = 2;
  }

  protected override void OnUpdate()
  {


    if (hurtTimer > 0)
    {
      hurtTimer -= Time.deltaTime;
      velocity = knockBackDirection * knockBackSpeed;
    }
    else
    {
      velocity = Vector2.zero;
    }

    controller.Move(velocity * Time.deltaTime);


    if (health <= 0)
    {
      Death();
    }
  }

  void Death()
  {
    if (!isDying)
    {
      GameObject prefab = Instantiate(deathPrefab, transform.position, Quaternion.identity);
      prefab.transform.parent = gameObject.transform;
      Destroy(gameObject, 0.5f);
      isDying = true;
    }
   

  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "LinkAttack")
    {
      link = GameObject.FindGameObjectWithTag("Player");
      knockBackDirection = CalculateDirection();
      knockBackDirection.Normalize();
      hurtTimer = 0.15f;
      health--;
    }
  }

  Vector2 CalculateDirection()
  {
    return new Vector2(transform.position.x - link.transform.position.x, transform.position.y - link.transform.position.y);
  }

  
  private void LateUpdate()
  {
    if (controller.collisions.above)
    {
      transform.position = new Vector3(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y),
      transform.position.z);
    }
    if (controller.collisions.right)
    {
      transform.position = new Vector3(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y),
        transform.position.z);
    }
    if (controller.collisions.left)
    {
      transform.position = new Vector3(Mathf.CeilToInt(transform.position.x), Mathf.CeilToInt(transform.position.y),
        transform.position.z);
    }
    if (controller.collisions.below)
    {
      transform.position = new Vector3(Mathf.CeilToInt(transform.position.x), Mathf.CeilToInt(transform.position.y),
        transform.position.z);
    }

    if (velocity == Vector2.zero)
    {
      transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y),
        transform.position.z);
    }
  }
}
