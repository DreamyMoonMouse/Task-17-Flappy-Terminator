using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isJump;
    private bool _isShoot;

    public bool IsJump => GetBoolAsTrigger(ref _isJump);
    public bool IsShoot => GetBoolAsTrigger(ref _isShoot);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isJump = true;
        
        if (Input.GetMouseButtonDown(0))
            _isShoot = true;
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}