using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Erlik : MonoBehaviour
{
    public GameObject Target;
    public GameObject Wall;
    public GameObject Iceball;
    public GameObject Mob;
    public GameObject HealthBar;
    public int health = 50;

    public Data have;
    void Start()
    {
        HealthBar.GetComponent<HealthBar>().SetMaxHealth(health);
        Target = GameObject.FindGameObjectWithTag("Player");
        //Shoot();
        StartCoroutine(Fight());
    }
    IEnumerator Fight()
    {
        //yield return new WaitForSeconds(10f);
        //Spawn();
        yield return new WaitForSeconds(0.5f);
        while (health > 0) {
            Shoot();
            yield return new WaitForSeconds(8f);
            Spawn();
            yield return new WaitForSeconds(10f);
        }
        HealthBar.GetComponent<HealthBar>().SetMaxHealth(20);
        health = 20;
        while (health > 0)
        {
            var angle = Random.Range(0, 2 * Mathf.PI);
            var len = Random.Range(5, 10);
            GameObject obj = Instantiate(Iceball, transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * len, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1f);
        Die();
    }
    void Die()
    {
        have.morg = true;
        SceneManager.LoadScene("SampleScene");
        Destroy(gameObject);
    }
    void Update()
    {
        HealthBar.GetComponent<HealthBar>().SetHealth(Mathf.Max(1, health));
        if (Target.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void Shoot()
    {
        for (int i = 0; i < 4; ++i)
        {
            float alpha = i * Mathf.PI * 2 / 4;
            Instantiate(Iceball, Target.transform.position + new Vector3(Mathf.Cos(alpha), Mathf.Sin(alpha), 0) * 10, Quaternion.identity);
        }
        for (int i = 0; i < 15; ++i)
        {
            float alpha = i * Mathf.PI * 2 / 15;
            GameObject obj = Instantiate(Wall, transform.position + new Vector3(Mathf.Cos(alpha), Mathf.Sin(alpha), 0) * 5, Quaternion.identity);
            obj.transform.localScale = new Vector3(15, 0, 15);
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
            obj.transform.localScale = new Vector3(5, 5, 5);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Fireball"))
        {
            health -= 1;
        }
    }
}
