using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Photon.Pun;

public abstract class PlayerController : MonoBehaviourPunCallbacks, IPlayerController
{

    [SerializeField] protected PlayerControllerSettingsPreset m_Preset;

    protected virtual void Update()
    {

        Keyboard keyboard = Keyboard.current;

        if (keyboard[m_Preset._upKey].isPressed)
        {
            MoveUp();
        }
        else if (keyboard[m_Preset._downKey].isPressed)
        {
            MoveDown();
        }
    }

    public abstract void MoveUp();
    public abstract void MoveDown();
}