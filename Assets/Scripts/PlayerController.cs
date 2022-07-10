using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float PullForce;
    public float MoveSpeed;
    public TextMeshProUGUI InteractionPrompt;
    Rigidbody2D Body;
    Vector2 InputDelta;
    List<Interactive> InteractiveObjectsInRange = new List<Interactive>();
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputDelta.x = Input.GetAxisRaw("Horizontal");
        InputDelta.y = Input.GetAxisRaw("Vertical");
        var closest = GetClosestInteractiveObject();
        if (closest != null)
        {
            InteractionPrompt.text = $"F - {closest.Prompt}";
            if (Input.GetKeyDown(KeyCode.F))
            {
                closest.Interact();
            }
        }
        else
        {
            InteractionPrompt.text = "";
        }
    }

    void FixedUpdate()
    {
        Body.velocity = InputDelta.normalized * MoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactive>(out var interactiveObject))
        {
            InteractiveObjectsInRange.Add(interactiveObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactive>(out var interactive))
        {
            for (var i = InteractiveObjectsInRange.Count - 1; i >= 0; i--)
            {
                var obj = InteractiveObjectsInRange[i];
                if (obj.GetInstanceID() == interactive.GetInstanceID())
                {
                    InteractiveObjectsInRange.RemoveAt(i);
                    break;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Draggable")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                var direction = transform.position - collision.transform.position;
                direction.Normalize();
                collision.attachedRigidbody.AddForce(direction * PullForce * Time.deltaTime);
            }
        }
    }

    private Interactive GetClosestInteractiveObject()
    {
        var min = float.MaxValue;
        Interactive closestObject = null;
        foreach (var obj in InteractiveObjectsInRange)
        {
            var distance = Vector3.Distance(obj.transform.position, transform.position);
            if (distance < min)
            {
                min = distance;
                closestObject = obj;
            }
        }
        return closestObject;
    }
}
