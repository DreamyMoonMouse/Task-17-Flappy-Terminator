using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const KeyCode JumpKey = KeyCode.Space;
    public const int ShootMouseButton = 0;
    
    private bool _isJump;
    private bool _isShoot;

    public bool IsJump => GetBoolAsTrigger(ref _isJump);
    public bool IsShoot => GetBoolAsTrigger(ref _isShoot);

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
            _isJump = true;
        
        if (Input.GetMouseButtonDown(ShootMouseButton))
            _isShoot = true;
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool wasPressed = value;
        value = false;
        return wasPressed;
    }
}