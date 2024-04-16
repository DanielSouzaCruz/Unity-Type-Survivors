using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D theRB;
    public float moveSpeed;
    public float damage;
    private Transform target;


    void Start()
    {
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = (target.position - transform.position).normalized * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealthController.instance.TakeDamage(damage);
        }
    }
}
