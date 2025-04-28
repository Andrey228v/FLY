using System;
using UnityEngine;

public class UserInputKeybord : MonoBehaviour, IUserInput
{
    private KeyCode _jumpKey = KeyCode.Space;
    private int _leftButtonMouse = 0;

    public event Action Jumped;
    public event Action Attacked;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            Jumped?.Invoke();
        }

        if (Input.GetMouseButtonDown(_leftButtonMouse))
        {
            Attacked?.Invoke();
        }
    }
}
