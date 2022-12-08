using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erlik : MonoBehaviour
{
    GameObject Target;
    GameObject Wall;
    GameObject Iceball;
    GameObject Mob;
    public int health = 50;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Fight());
    }
    IEnumerator Fight()
    {
        while (health > 0) {
            Shoot();
            yield return new WaitForSeconds(10f);
            Spawn();
            yield return new WaitForSeconds(10f);
        }
        for (int i = 0; i < 19; ++i)
        {
            var angle = Random.Range(0, 2 * Mathf.PI);
            var len = Random.Range(5, 10);
            GameObject obj = Instantiate(Iceball, transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * len, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(15f);
        Die();
    }
    void Die()
    {

    }
    void Update()
    {
        
    }

    void Shoot()
    {
        float x = Target.transform.position.x;
        float y = Target.transform.position.y;
        for (int i = 0; i < 3; ++i)
        {
            float alpha = i * Mathf.PI * 2 / 3;
            Instantiate(Iceball, Target.transform.position + new Vector3(Mathf.Cos(alpha), Mathf.Sin(alpha), 0) * 5, Quaternion.identity);
        }
        for (int i = 0; i < 36; ++i)
        {
            float alpha = i * Mathf.PI * 2 / 36;
            GameObject obj = Instantiate(Wall, transform.position + new Vector3(Mathf.Cos(alpha), Mathf.Sin(alpha), 0) * 5, Quaternion.identity);
            //obj.GetComponent<WallControl>().block = true;
        }
    }
    void Spawn()
    {
        StartCoroutine(Summoning());
    }
    IEnumerator Summoning()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 10; ++i)
        {
            var angle = Random.Range(0, 2 * Mathf.PI);
            var len = Random.Range(5, 10);
            GameObject obj = Instantiate(Mob, transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * len, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
