using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalValue;
    private float verticalValue;
    public float moveSpeed = 1f;
    public float movementSpeed;
    public float FireBall_Speed = 1.0f;
    private Vector2 movementInput;


    private Rigidbody2D rb;
    private Animator animator;

    public GameObject Stuff;
    private FaderTree fade;

    private Vector2 shooTing;
    private Vector2 LocalshooTing;

    public GameObject Aim;

    private bool facingRight = false;

    public GameObject firePrefab;

    private float timeShots;
    private float timeDash = 0.5f;
    private float dashCount;
    private Vector2 dashDirection;

    public float startTimeShots;
    //public float startTimeDash = 1;

    public Transform Dulo;

    public float offset;

    private float reverse = 1f;

    [SerializeField] private TrailRenderer tr;

    bool DashCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //Анимация
    private void FixedUpdate()
    {
        if (dashCount <= 0)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            DashCheck = false;
            tr.emitting = false;
            ProcessInputs();
            GameObject.Find("HitBox").GetComponent<BoxCollider2D>().enabled = true;
            //GetComponent<CapsuleCollider2D>().enabled = true;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Dash");
            animator.SetBool("IsMoving", false);
            tr.emitting = true;
            dashCount -= Time.deltaTime;
            Debug.Log(dashCount);
            rb.MovePosition(rb.position + dashDirection * 30 * Mathf.Cos((timeDash-dashCount)/timeDash*Mathf.PI/2) * Time.fixedDeltaTime);
        }
        AimWork();
        //Debug.Log(shooTing.x);
        if (shooTing.x >= transform.position.x && !facingRight)
        {
            /*Turn = true;*/
            Flip();
            reverse = -1f;
        }
        else if (shooTing.x < transform.position.x && facingRight)
        {
            /*Turn = true;*/
            Flip();
            reverse = 1f;
        }


        if (movementInput != Vector2.zero && !DashCheck)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private void Update()
    {
        if (timeShots <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Stuff.GetComponent<Animator>().SetBool("AttackStuff", true);
                Invoke(nameof(Shoot), 0.1f);
            }
        }
        else
        {
            Stuff.GetComponent<Animator>().SetBool("AttackStuff", false);
            timeShots -= Time.deltaTime;
        }
        if (dashCount <= 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //Stuff.GetComponent<Animator>().SetBool("Dash", true);
                //Invoke(nameof(Dash), 0.1f);
                Dash();
            }
        }
        else
        {
            //Stuff.GetComponent<Animator>().SetBool("AttackStuff", false);
            //dashCount -= Time.deltaTime;
        }
    }

    //Поворот персонажа влево или права
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    //Ходьба Персонажа
    void ProcessInputs()
    {

        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(horizontalValue, verticalValue);
        movementSpeed = Mathf.Clamp(movementInput.magnitude, 0.0f, 1.0f);

        movementInput.Normalize();
        if (movementInput != Vector2.zero)
        {
            rb.MovePosition(rb.position + movementInput * moveSpeed * movementSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tree")
        {
            fade = collision.GetComponent<FaderTree>();
            fade.FadeOut();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tree")
        {
            fade = collision.GetComponent<FaderTree>();
            fade.FadeIn();
        }
    }

    void AimWork()
    {
        shooTing = Aim.transform.position;
        
        LocalshooTing = Aim.transform.localPosition;
        LocalshooTing.Normalize();
        LocalshooTing = new Vector2(reverse * LocalshooTing.x, LocalshooTing.y - offset);
    }

    public void Shoot()
    {
        timeShots = startTimeShots;
        GameObject fireBall = Instantiate(firePrefab, Dulo.transform.position, Quaternion.identity);
        fireBall.GetComponent<Rigidbody2D>().AddForce(LocalshooTing * FireBall_Speed, ForceMode2D.Impulse);
        float rotZ = Mathf.Atan2(LocalshooTing.y, LocalshooTing.x) * Mathf.Rad2Deg;
        fireBall.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        //Destroy(fireBall, 3.0f);
    }
    public void Dash()
    {
        DashCheck = true;
        dashDirection = LocalshooTing;
        transform.GetChild(3).GetComponent<BoxCollider2D>().enabled = false;
        //GetComponent<CapsuleCollider2D>().enabled = false;
        dashCount = timeDash;
        //gameObject.GetComponent<Rigidbody2D>().AddForce(LocalshooTing * 10, ForceMode2D.s );
        //gameObject.GetComponent<Rigidbody2D>().AddForce(LocalshooTing * 10, ForceMode2D.Force);
    }
}
