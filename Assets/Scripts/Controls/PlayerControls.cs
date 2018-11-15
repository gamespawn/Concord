using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerControls
{
    #region InGameControls
    public static void Move(this Player player, float xAxis, float zAxis)
    {
        player.RigidBody.velocity = new Vector3(xAxis, player.RigidBody.velocity.y, zAxis);
    }
    #endregion
}
