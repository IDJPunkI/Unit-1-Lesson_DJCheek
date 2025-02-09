using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Vector3 direction = Vector3.zero;

    [SerializeField]
    private float forceMultiplier = 1.0f;

    [SerializeField]
    private ForceMode forceMode;
    public GameObject spawnPoint;
    private Dictionary<Item.VegetableType, int> inventory = new Dictionary<Item.VegetableType, int>();

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();

        foreach (Item.VegetableType type in System.Enum.GetValues(typeof(Item.VegetableType)))
        {
            inventory.Add(type, 0);
        }
    }

    void Update()
    {
        float horizontalVelocity = Input.GetAxis("Horizontal");
        float verticalVelocity = Input.GetAxis("Vertical");

        direction = new Vector3(horizontalVelocity, 0, verticalVelocity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbPlayer.AddForce(direction * forceMultiplier, forceMode);

        if (transform.position.z > 38)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 38);
        }
        else if (transform.position.z < -38)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -38);
        }
    }

    private void Respawn()
    {
        rbPlayer.MovePosition(spawnPoint.transform.position);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Item"))
        {
            Item item = collider.gameObject.GetComponent<Item>();
            AddItemToInventory(item);
            PrintInventory();
        }
    }

    private void AddItemToInventory(Item item)
    {
        inventory[item.typeOfVeggie]++;
    }

    private void PrintInventory()
    {
        string output = "";

        foreach (KeyValuePair<Item.VegetableType, int> pair in inventory)
        {
            output += string.Format("{0}: {1}; ", pair.Key, pair.Value);
        }

        Debug.Log(output);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Hazard"))
        {
            Respawn();
        }
    }
}
