using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour
{
    public GameManager gm;
    Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float volume = Mathf.Clamp(rb.velocity.magnitude / 10f, 0.05f, 0.3f);
        AudioManager.instance.Play("hitGround", volume);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
}
