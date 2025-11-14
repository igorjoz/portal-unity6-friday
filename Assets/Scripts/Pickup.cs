using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Picked();
        }
    }

    public virtual void Picked()
    {
        Debug.Log("Pickup collected!");
        Destroy(gameObject);
    }
}
