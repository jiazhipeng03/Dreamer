using UnityEngine;
using System.Collections;

public class Enemy : Character
{

    // Use this for initialization
    protected new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BeAttack(int damage)
    {
        m_HP -= damage;
        if (m_HP <= 0)
            Destroy(gameObject);
    }
}
