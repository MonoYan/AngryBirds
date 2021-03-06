using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBird : Birds
{
    public override void ShowSkill()
    {
        base.ShowSkill();
        Vector3 speed = rb.velocity;
        speed.x *= -1;
        rb.velocity = speed;
    }
}
