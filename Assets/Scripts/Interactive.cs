using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive : MonoBehaviour
{
    public string Prompt;
    public UnityEvent Interaction;
    public void Interact()
    {
        Interaction?.Invoke();
    }
}
