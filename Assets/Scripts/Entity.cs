using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Entity : MonoBehaviour
{
    public int ID
    {
        get;
        private set;
    }

    protected abstract void Hit();
}
