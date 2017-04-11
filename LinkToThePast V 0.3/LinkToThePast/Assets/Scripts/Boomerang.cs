using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Boomerang : BaseItem
{
  public override void ExecuteItem()
  {
    
  }

  public override void  UseItem()
  {

  }

  public override BaseState GetBehaviour(Link link)
  {
    return new BoomerangBehaviour(link, this);
  }

  public override bool HasBehaviour
  {
    get { return true; }
  }

}


