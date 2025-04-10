using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HivePickUp : MonoBehaviour
{
    public delegate void PickUpHive();
    public static event PickUpHive HivePickedUp;

    private void Start()
    {
        //NavPlayerMovement.DroppedHive += OnHiveDrop;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            HivePickedUp?.Invoke();
            gameObject.SetActive(false);
        }
    }

    void OnHiveDrop(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
}
