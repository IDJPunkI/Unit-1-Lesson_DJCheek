using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class CountGUI : NetworkBehaviour
{
    private TextMeshProUGUI tmProElement;

    public string itemName;

    public NetworkVariable<int> count = new NetworkVariable<int>;

    // Start is called before the first frame update
    void Start()
    {
        tmProElement = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCount()
    {
        count.Value++;
    }

    public void UpdateText()
    {
        tmProElement.text = itemName + ": " + count.Value;
    }
}
