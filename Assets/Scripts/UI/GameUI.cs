using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI gameUI;

    private void Awake()
    {
        gameUI = this;
    }

    public DynamicJoystick _moveJoystick;
    public DynamicJoystick _gunJoystick;

    private void OnDestroy()
    {
        gameUI = null;
    }


}
