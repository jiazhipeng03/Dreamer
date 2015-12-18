using UnityEngine;
using System.Collections;

public class Player : Character{
    // Use this for initialization
    private Transform m_AttackPoint;
    protected new void Start()
    {
        base.Start();
        m_AttackPoint = transform.Find("AttackPoint");
    }

    // Update is called once per frame
    void Update () {
        float fX = Input.GetAxis("Horizontal");
        m_RigidBody2D.velocity = new Vector2(fX * m_Speed, m_RigidBody2D.velocity.y);
        
        if(m_bOnGround && Input.GetButton("Jump"))
        {
            m_bJump = true; 
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        if (transform.position.y < -6)
            Application.LoadLevel(0);
    }

    void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_AttackPoint.position, 0.3f, LayerMask.NameToLayer("enemy"));
        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject.tag == "enemy")
                colliders[i].gameObject.GetComponent<Enemy>().BeAttack(m_Atk);
                
        }
        //m_bAttack = true;
        //anim.attack = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "enemy" && m_bAttack)
        //    other.gameObject.GetComponent<Enemy>().BeAttack(m_Atk);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "platform")
            m_bOnGround = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "platform")
            m_bOnGround = false;
    }
}
