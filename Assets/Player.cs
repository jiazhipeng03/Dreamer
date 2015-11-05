using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private float m_Speed = 10f;
    [SerializeField]
    private int m_JumpForce = 500;

    private Rigidbody2D m_RigidBody2D;
    private bool m_bJump = false;
    private bool m_bOnGround = false;
	// Use this for initialization
	void Start () {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float fX = Input.GetAxis("Horizontal");
        m_RigidBody2D.velocity = new Vector2(fX * m_Speed, m_RigidBody2D.velocity.y);
        if (m_bOnGround && Input.GetButtonDown("Jump"))
        {
            m_bJump = true;
        }

    }

    void FixedUpdate()
    {
        
        if (m_bOnGround && m_bJump)
        {            
            m_RigidBody2D.AddForce(new Vector2(0, m_JumpForce));
            m_bJump = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "platform")
            m_bOnGround = true;
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
