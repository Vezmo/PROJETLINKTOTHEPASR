using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState {

  public abstract EnemyBaseState Update(GreenGuard greenGuard, Orientation current);

  public abstract void GetHurt(Vector2 knockback, int damage);
}
