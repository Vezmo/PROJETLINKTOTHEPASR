using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    Vector3 salle1 = new Vector3(-30, 280, -10);
    Vector3 salle2 = new Vector3(225, 268, -10);
    Vector3 salle4 = new Vector3(-30, 630, -10);
    Vector3 salle7 = new Vector3(368, 999, -10);
    Vector3 salle8 = new Vector3(368, 1240, -10);

    // Use this for initialization
    void Start() {

    }

    //Si target est en OnTriggerStay

    //Dans une salle nommée Salle 1





    void Update() {
    }


    public void Salle1()
    {
        transform.position = salle1;
    }
    public void Salle2()
    {
        transform.position = salle2;
    }
    public void Salle3()
    {
        transform.position = new Vector3(225, target.position.y, -10);
    }
    public void Salle4()
    {
        transform.position = salle4;
    }
    public void Salle5()
    {
        transform.position = new Vector3(target.position.x, 629, -10);
    }
    public void Salle6()
    {
        transform.position = new Vector3(625, target.position.y, -10);
    }
    public void Salle7()
    {
        transform.position = salle7;
    }
    public void Salle8()
    {
        transform.position = salle8;
    }
  void LateUpdate()
  {
   
  }
}
