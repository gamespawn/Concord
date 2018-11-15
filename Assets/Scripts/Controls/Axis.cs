using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis
{
    private string AxisName;

    public Axis(string AxisName)
    {
        this.AxisName = AxisName;
    }

    public float GetAxis()
    {
        return Input.GetAxis(AxisName);
    }
}
