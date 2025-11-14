using UnityEngine;

public class Key : Pickup
{
    [SerializeField] private KeyColor keyColor;

    public override void Picked()
    {
        base.Picked();
        GameManager.instance.AddKey(keyColor);
    }
}

public enum KeyColor
{
    Gold, Green, Red
}