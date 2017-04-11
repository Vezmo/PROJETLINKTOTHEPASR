using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState {

  float attackDuration;
  bool isAnimated;

  public AttackState()
  {
    isAnimated = false;
    attackDuration = 0.233f;
  }


  public override BaseState Update(Link link, Orientation current)
  {

    if (!isAnimated)
    {
      if (current == Orientation.Down)
      {
        link.anim.Play("DownSwing", 0, 0f);
      }
      if (current == Orientation.Right || current == Orientation.Left)
      {
        link.anim.Play("SideSwing", 0, 0f);
      }
      if (current == Orientation.Up)
      {
        link.anim.Play("UpSwing", 0, 0f);
      }
      isAnimated = true;
    }

      link.velocity = Vector2.zero;

    if (Input.GetButtonDown("Attack"))
    {
      return new AttackState();
    }


    if (attackDuration > 0)
    {
      attackDuration -= Time.deltaTime;
    }
    else
    {
      return new DefaultState();
    }



    return this;
  }


  
}
