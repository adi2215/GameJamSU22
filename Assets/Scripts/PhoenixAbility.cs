using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixAbility : MonoBehaviour
{
    // Start is called before the first frame update
    float cool = 0;
    public float cooldown = 20f;
    public GameObject Particle;
    GameObject Target;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Target.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        cool -= Time.deltaTime;
        if (cool < 0 && Input.GetKeyDown(KeyCode.E))
        {
            
            for (int i = 0; i < 36; ++i)
            {
                float alpha = i * Mathf.PI * 2 / 36;
                var obj = Instantiate(Particle, transform.position, Quaternion.identity);
                Vector2 direction = new Vector2(Mathf.Sin(alpha), Mathf.Cos(alpha));
                obj.GetComponent<Rigidbody2D>().AddForce(direction*300, ForceMode2D.Force);
                //obj.GetComponent<Rigidbody2D>().AddForce(direction * direction, ForceMode2D.Impulse);
                float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                obj.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            }
            cool = cooldown;
        }
        if (cool < 20-3)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) > 5)
            {
                transform.position += Vector3.Normalize(Target.transform.position - transform.position) * 11f * Time.deltaTime;
                //Debug.Log(Target.transform.position.ToString() + Vector3.Normalize(Target.transform.position - transform.position).ToString());
            } else if (Vector3.Distance(transform.position, Target.transform.position) > 4)
            {
                transform.position += Vector3.Normalize(Target.transform.position - transform.position) * (Vector3.Distance(transform.position, Target.transform.position)-4f) * 10 * Time.deltaTime;
            }
        }
    }
}
