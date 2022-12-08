using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    bool decay = false;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        StartCoroutine(Decay());
    }
    private void Update()
    {
        if (decay)
        {
            //GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);

            GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, Time.deltaTime);
            Debug.Log(GetComponent<SpriteRenderer>().color.a);
        }
    }
    IEnumerator Decay()
    {
        yield return new WaitForSeconds(2f);
        decay = true;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Destroy(gameObject);
        }
    }
}
