using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamage : MonoBehaviour
{
    public GameObject Coin;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fireball"))
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
