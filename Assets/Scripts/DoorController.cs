using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public HingeJoint2D Hinge;
    public bool Locked;
    private bool _locked;
    JointAngleLimits2D UnlockedLimits;
    private void Awake()
    {
        UnlockedLimits = Hinge.limits;
    }

    private void Update()
    {
        if (Locked != _locked)
        {
            _locked = Locked;
            if (_locked)
            {
                Lock();
            }
            else
            {
                Unlock();
            }
        }
    }

    public void Lock()
    {
        Hinge.limits = new JointAngleLimits2D { max = 0, min = 0 };
    }

    public void Unlock()
    {
        Hinge.limits = UnlockedLimits;
    }

    public void Toggle()
    {
        Locked = !Locked;
    }
}
