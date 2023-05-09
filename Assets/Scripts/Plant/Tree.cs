using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Plant
{
    public override void Collect()
    {

    }

    public override void OnGrown()
    {
        Score.Instance.AddXp(Settings.XP);
    }
}
