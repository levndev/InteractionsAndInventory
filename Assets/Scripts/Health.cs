using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnDeath;
    public float Max;
    public float Current
    {
        get => current;
        private set
        {
            current = value;
        }
    }
    private float current;

    void Awake()
    {
        current = Max;
    }

    public float TakeDamage(float damage)
    {
        Current -= damage;
        if (Current <= 0)
        {
            OnDeath?.Invoke();
        }
        return Current;
    }

    public float Replenish(float amount)
    {
        Current += amount;
        if (Current > Max)
        {
            Current = Max;
        }
        return Current;
    }
}