using UnityEngine;

public class UserInputKeybord : MonoBehaviour, IUserInput
{
    private KeyCode _jumpKey = KeyCode.Space;
    private int _leftButtonMouse = 0;

    public bool Jump { get; private set; }
    public bool Attack { get; private set; }

    private void Update()
    {
        Jump = Input.GetKeyDown(_jumpKey);
        Attack = Input.GetMouseButtonDown(_leftButtonMouse);
    }
}
