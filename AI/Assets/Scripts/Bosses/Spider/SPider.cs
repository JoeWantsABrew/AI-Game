using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPider : MonoBehaviour
{
    public Transform target;
    public float LookSpeed;
    public Rigidbody2D rigid;
    public float MoveMentSpeed;
    public bool CanHurt;
    public Transform forth;
    public float dashSpeed;
    public float SocialDistance;
    public GameObject lasser;
    public Transform LeftEye;
    public Transform RightEye;
    private bool CanMove;
    private bool CanRotate;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();


        StartCoroutine(Attack());
        CanRotate = true;
        CanMove = true;
    }

    private void Update()
    {
        if (CanMove)
        {
            Move();
        }
        if (CanRotate)
        {
            LerpRotation();
        }
    }

    public void LerpRotation()
    {
        var RelativePos = transform.position - target.position;
        float quat = Mathf.Atan2(RelativePos.y, RelativePos.x);
        Quaternion accRotation = Quaternion.Euler(0, 0, (Mathf.Lerp(transform.rotation.z, quat, LookSpeed * Time.deltaTime) * Mathf.Rad2Deg) + 90);
        transform.rotation = accRotation;
    }

    public void Move()
    {
        var Moveee = ((target.position - transform.position).normalized) * MoveMentSpeed;
        if ((target.position - transform.position).magnitude > SocialDistance)
        {
            rigid.velocity = Moveee;
        }
        else
        {
            rigid.velocity = -Moveee;
        }
    }

    IEnumerator Attack()
    {
        //rigid.freezeRotation = false;
        SpriteRenderer rendereee = GetComponentInChildren<SpriteRenderer>();
        CanHurt = false;
        CanMove = true;
        CanRotate = true;
        rendereee.color = new Color(1, 1, 1, 1f);
        yield return new WaitForSeconds(Random.Range(4, 8));

        int ATK = Random.Range(1, 3);

        if (ATK == 1)
        {
            rendereee.color = new Color(1, 1, 1, 0.1f);
            CanMove = false;
            CanRotate = false;
            Invoke("CompleteDashAttack", 2);
            Debug.Log("Dash");
            //rigid.freezeRotation = true;
        }
        else
        {
            Instantiate(lasser, LeftEye.position, LeftEye.rotation);
            Instantiate(lasser, RightEye.position, LeftEye.rotation);
            StartCoroutine(Attack());
        }
    }

    public void GoBackToAttack()
    {
        StartCoroutine(Attack());
    }

    public void CompleteDashAttack()
    {
        CanHurt = true;
        Vector3 GoHere = (forth.position - transform.position).normalized;
        rigid.velocity = GoHere * dashSpeed;
        Invoke("GoBackToAttack", 1);
    }
}
