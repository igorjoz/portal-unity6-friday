using UnityEngine;

public class Crystal : Pickup
{
    [SerializeField] private int points = 5;

    public override void Picked()
    {
        base.Picked();
        GameManager.instance.AddPoints(points);
    }
}
