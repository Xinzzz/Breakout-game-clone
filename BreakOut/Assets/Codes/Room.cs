using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    Vector3 offset;
    Vector3 screenPoint;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    public GameManager gm;
    public float dragSpeed = 15f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if(gm.okToDrag)
        {
            rb.velocity = (curPosition - transform.position) * dragSpeed;
        }      
    }

    private void OnMouseUp()
    {
        rb.velocity = Vector3.zero;
    }
}
