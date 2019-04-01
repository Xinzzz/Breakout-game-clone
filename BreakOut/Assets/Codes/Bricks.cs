using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public string brickName;
    GameManager gm;
    Rigidbody2D ballRb;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(brickName == "Green")
        {
            Destroy(gameObject);
            AudioManager.instance.Play("hitGreen", 0.6f);
            gm.greenBricks.Remove(gameObject);
            gm.CountGreenBrick();
        }
        else if(brickName == "Red")
        {
            AudioManager.instance.Play("hitRed", 0.6f);
            gm.gameOver = true;
        }
        else if(brickName == "Yellow")
        {
            AudioManager.instance.Play("hitYellow", 0.5f);
            collision.transform.GetComponent<Rigidbody2D>().AddForce(transform.up * 700f);
        }
        
    }
}
