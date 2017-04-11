using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{



  public abstract void ExecuteItem();

  public virtual bool HasBehaviour { get { return false; } }

  public abstract BaseState GetBehaviour(Link link);

  public abstract void UseItem();


}
