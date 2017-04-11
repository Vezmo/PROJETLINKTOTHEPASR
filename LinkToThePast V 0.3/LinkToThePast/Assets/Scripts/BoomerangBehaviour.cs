using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBehaviour : BaseState
{

  private Boomerang _boom;
  private Link link;


  public BoomerangBehaviour(Link link, Boomerang boom)
  {
    
  }

  public override BaseState Update(Link link, Orientation current)
  {



    //boom.useItem à la fin du timer

    return this;
  }
}
