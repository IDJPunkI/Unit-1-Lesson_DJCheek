using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class SpawnManager : NetworkBehaviour
{
    public GameObject[] lilypads;

    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        if (!IsServer)
        {
            return;
        }

        InvokeRepeating("SpawnLilyPad", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnLilyPad()
    {
        foreach (GameObject lilypad in lilypads)
        {
            NetworkObject lilyPadObject = Instantiate(lilypad).GetComponent<NetworkObject>();
            lilyPadObject.Spawn();
        }
    }
}
