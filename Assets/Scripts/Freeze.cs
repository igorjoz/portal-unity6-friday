using UnityEngine;

public class Freeze : Pickup
{
    [SerializeField] private int freezeTime = 10;

    public override void Picked()
    {
        base.Picked();
        GameManager.instance.FreezeTime(freezeTime);
    }
}
