using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DefaultState : BaseOrientedState
{


    public DefaultState()
    {}


  public override BaseState Update(Link link, Orientation currentOrientation)
  {
    base.Update(link, currentOrientation);

    Vector2 directionalInput = link.directionalInput;
    link.moveSpeed = link.baseSpeed;
    link.velocity = directionalInput * link.moveSpeed;
    link.controller.Move(link.velocity * Time.deltaTime);

    if (Input.GetButtonDown("Attack"))
    {
      
    }

    if (Input.GetButtonDown("Charge"))
    {
            return new BufferingChargeState();
    }
    //if (Input.GetButtonDown("UseItem"))
    //{
      //UseItem(link.currentItem, Orientation currentOrientation);
    //}

    return this;
  }
}
