using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PullForce;
    public float MoveSpeed;
    Rigidbody2D Body;
    Vector2 InputDelta;
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputDelta.x = Input.GetAxisRaw("Horizontal");
        InputDelta.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Body.velocity = InputDelta.normalized * MoveSpeed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Draggable")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                var direction = transform.position - collision.transform.position;
                direction.Normalize();
                collision.attachedRigidbody.AddForce(direction * PullForce);
            }
        }
    }
}
