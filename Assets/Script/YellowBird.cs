using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Birds
{

    /// <summary>
    /// ��д����
    /// </summary>
    public override void ShowSkill()
    {
        base.ShowSkill();
        rb.velocity *= 2.3f;
    }
}
