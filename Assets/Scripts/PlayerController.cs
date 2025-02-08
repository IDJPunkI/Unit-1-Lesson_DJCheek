using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalVelocity = Input.GetAxis("Horizontal");

        rbPlayer.AddForce(horizontalVelocity, 0, 0, ForceMode.Impulse);
    }
}
