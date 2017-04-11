using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Link : Framework
{

  public Vector2 velocity;

  public Vector2 directionalInput;
  public Controller2D controller;
  public int baseSpeed = 95;
  public int moveSpeed = 95;


    //à mettre ptet dans inventory
    public int currentItemIndex;


  public Orientation currentOrientation;
  private Orientation startingOrientation = Orientation.Down;
  public Orientation oldOrientation;
  public bool isOrientedDown;
  public bool isOrientedRight;
  public bool isOrientedUp;
  public BaseState state;
  public Animator anim;
  public SpriteRenderer renderer;
  private bool canFlip;
  public float attackDuration;
  public bool isAttacking = false;
  public bool isBufferingCharge = false;
  public bool isCharging = false;
  public GameObject SmokePrefab;

  protected override void OnStart()
  {
    currentOrientation = Orientation.Down;
    oldOrientation = currentOrientation;
    anim = GetComponent<Animator>();
    renderer = GetComponent<SpriteRenderer>();
    controller = GetComponent<Controller2D>();
    state = new DefaultState();
  }

  protected override void OnUpdate()
  {
    directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    directionalInput.Normalize();


    state = state.Update(this, currentOrientation);
     
    AnimatorStuff();

    oldOrientation = currentOrientation; // refresh the oldOrientation before changing frame

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
    void AnimatorStuff()
  {

    //For Animator purposes only
    isOrientedRight = (currentOrientation == Orientation.Left || currentOrientation == Orientation.Right);
    isOrientedUp = currentOrientation == Orientation.Up;
    isOrientedDown = currentOrientation == Orientation.Down;


    anim.SetInteger("velocityX", (int) velocity.x);
    anim.SetInteger("velocityY", (int) velocity.y);

    anim.SetBool("isAttacking", isAttacking);
    anim.SetBool("isOrientedDown", isOrientedDown);
    anim.SetBool("isOrientedRight", isOrientedRight);
    anim.SetBool("isOrientedUp", isOrientedUp);
    anim.SetBool("isBufferingCharge", isBufferingCharge);

  }

}
