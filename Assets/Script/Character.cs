using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected float m_Speed = 10f;
    [SerializeField]
    protected int m_JumpForce = 500;
    [SerializeField]
    protected int m_Atk = 5;
    [SerializeField]
    protected int m_HP = 10;

    protected Rigidbody2D m_RigidBody2D;
    protected Transform m_Trans;
    protected bool m_bJump = false;
    protected bool m_bOnGround = false;
    protected bool m_bAttack = false;

    // Use this for initialization
    protected virtual void Start()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_Trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (m_bOnGround && m_bJump)
        {
            m_RigidBody2D.AddForce(new Vector2(0, m_JumpForce));
            m_bJump = false;
        }
    }   
}
