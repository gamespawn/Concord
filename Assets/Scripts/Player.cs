using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : Entity
{
    public Rigidbody RigidBody{ get; private set; }

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    protected override void Hit()
    {
        throw new System.NotImplementedException();
    }
}
