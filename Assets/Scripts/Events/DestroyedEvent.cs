using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedEvent : MonoBehaviour, IDestructible
{
    public event Action IDied;

    public void OnDestruction(GameObject destroyer)
    {
        if (IDied != null)
        {
            IDied();
        }
    }
}