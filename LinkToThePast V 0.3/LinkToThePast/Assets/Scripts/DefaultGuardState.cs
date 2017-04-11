using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGuardState : EnemyBaseState {




  public override EnemyBaseState Update(GreenGuard greenGuard, Orientation current)
  {




    return this;
  }




  public override void GetHurt(Vector2 knockback, int damage)
  {
    
  }


  
}
