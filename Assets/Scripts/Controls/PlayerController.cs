using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    private KeyBinds keyBinds;
    private Player player;

    private ControlsState controlsState;

    private enum ControlsState
    {
        Menu = 0,
        InGame,
        MAX
    }

    private void Awake()
    {
        player = GetComponent<Player>();
        keyBinds = ControllerMapping.GetKeyBinds(player.ID);
    }

    private void Update()
    {
        switch (controlsState)
        {
            case ControlsState.Menu:
                MenuControls();
                break;
            case ControlsState.InGame:
                InGameControls();
                break;
            case ControlsState.MAX:
            default:
                break;
        }
    }

    private void InGameControls()
    {
        player.Move(keyBinds.InGameKeys.Horizontal.GetAxis(),
            keyBinds.InGameKeys.Vertical.GetAxis());
    }

    private void MenuControls()
    {

    }
}
