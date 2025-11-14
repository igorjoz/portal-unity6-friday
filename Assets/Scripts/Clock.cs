using UnityEngine;

public class Clock : Pickup
{
    [SerializeField] private int timeToAdd = 10;

    public override void Picked()
    {
        base.Picked();
        GameManager.instance.AddTime(timeToAdd);
    }
}
