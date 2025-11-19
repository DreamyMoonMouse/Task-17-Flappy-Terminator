using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlaneMuvier : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    
    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    
    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.linearVelocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
    
    public void Reset()
    {
        transform.position = _startPosition;
        _rigidbody2D.linearVelocity = Vector2.zero;
        transform.rotation = Quaternion.identity;
    }
}
