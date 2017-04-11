using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingState : BaseOrientedState
{
    private int chargeSpeed;
    private float dashLength;
    private float dashTimer;
    public float smokeFxDuration;
    public GameObject SmokePrefab;


    public ChargingState()
    {   
        chargeSpeed = 190;
        dashTimer = 0f;
        smokeFxDuration = 0.2f;
    }

    public override BaseState Update(Link link, Orientation currentOrientation)
    {
        link.moveSpeed = chargeSpeed;
        link.isCharging = true;
        link.isBufferingCharge = false;
        base.Update(link, currentOrientation);

        switch (link.currentOrientation)
        {
            case Orientation.Left:
                link.directionalInput = Vector2.left;
                break;
            case Orientation.Right:
                link.directionalInput = Vector2.right;
                break;
            case Orientation.Up:
                link.directionalInput = Vector2.up;
                break;
            case Orientation.Down:
                link.directionalInput = Vector2.down;
                break;
            default:
                break;
        }
        Vector2 directionalInput = link.directionalInput;

        link.velocity = directionalInput * link.moveSpeed;
        link.controller.Move(link.velocity * Time.deltaTime);

        dashTimer += Time.deltaTime; // we update the dashTimer

        // smoke fx
        smokeFxDuration -= Time.deltaTime;
        if (smokeFxDuration < 0)
        {
            Vector3 smokePosition;
            int offset = 15;
            int y_offset = 5;
            switch (link.currentOrientation)
            {
                // set la position de la smoke selon l'orientation
                case Orientation.Left:
                    smokePosition = new Vector3(link.transform.position.x + offset, link.transform.position.y- y_offset,
                        link.transform.position.z);
                    break;
                case Orientation.Right:
                    smokePosition = new Vector3(link.transform.position.x - offset, link.transform.position.y - y_offset,
                        link.transform.position.z);
                    break;
                case Orientation.Down:
                    smokePosition = new Vector3(link.transform.position.x, link.transform.position.y + offset,
                        link.transform.position.z);
                    break;
                // default = up
                default:
                    smokePosition = new Vector3(link.transform.position.x, link.transform.position.y - offset,
                        link.transform.position.z);
                    break;
            }
            Link.Instantiate(link.SmokePrefab,smokePosition, link.transform.rotation);
            smokeFxDuration = 0.1f;
        }

        if (link.controller.collisions.above || link.controller.collisions.below || link.controller.collisions.left || link.controller.collisions.right)
        {
            link.isCharging = false;
            return new DefaultState();
        }

        if (link.oldOrientation != link.currentOrientation)
        {
            link.isCharging = false;
            return new DefaultState();
        }
        dashTimer += Time.deltaTime;
        return this;
    }
}
