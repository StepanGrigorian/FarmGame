using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Plant
{
    public override void Collect()
    {
        ParentBed.currentPlant = null;
        Score.Instance.AddXp(Settings.XP);
        Score.Instance.AddCarrots(1);
        Destroy(gameObject);
    }

    public override void OnGrown()
    {
        isCollectable = true;
    }
}
