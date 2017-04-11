using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferingChargeState : BaseOrientedState
{
    private float bufferingDelay;
    private float bufferingTimer;
    public float smokeFxDuration;
    public GameObject SmokePrefab;

    public BufferingChargeState()
    {
        bufferingDelay = 0.5f;
        bufferingTimer = 0.0f;
        smokeFxDuration = 0f;
    }
    public override BaseState Update(Link link, Orientation currentOrientation)
    {
        bufferingTimer += Time.deltaTime;
        link.moveSpeed = 0;
        link.isBufferingCharge = true;
        base.Update(link, currentOrientation);

        Vector2 directionalInput = link.directionalInput;

        link.velocity = directionalInput * link.moveSpeed;
        link.controller.Move(link.velocity * Time.deltaTime);

        // spawn smoke under link's feet
        // smoke fx
        smokeFxDuration -= Time.deltaTime;
        if (smokeFxDuration < 0)
        {
            Vector3 smokePosition = new Vector3(link.transform.position.x, link.transform.position.y-10f,
                link.transform.position.z);

            Link.Instantiate(link.SmokePrefab, smokePosition, link.transform.rotation);
            smokeFxDuration = 0.1f;
        }
        // if we change direction while charging dash
        if (link.oldOrientation != link.currentOrientation)
        {
            link.isBufferingCharge = false;
            return new DefaultState();
        }
        if (Input.GetButtonUp("Charge")) 
        {
            link.isBufferingCharge = false;
            return new DefaultState();
        }
        if (bufferingTimer > bufferingDelay)
        {
            link.isBufferingCharge = false;
            return new ChargingState();
        }
        return this;
    }
}
