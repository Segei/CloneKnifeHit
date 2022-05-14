using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class LogController : MonoBehaviour, IController
{
    public UnityEvent HitOnLog;
    private Rigidbody _rigidbody;
    [SerializeField] private float _maxSpeed = 4f;
    [SerializeField] private float _minSpeed = 0.5f;
    private float _speed = 1f;
    private int _direction = 1;
    [SerializeField] private float _delay;
    public static float AngularVelosityZ = 0;
    private Vector3 _angularVeloscity;

    private void Start()
    {
        _delay = Time.time + 0.5f;
    }
    private void Awake()
    {
        GlobalProperty.LogController = this;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        _rigidbody.angularVelocity = new Vector3(0, 0, 1) * 10;
    }
    public void HitOnMe()
    {
        GlobalProperty.Sounds.PlayLogHit();
        HitOnLog?.Invoke();
    }

    private void Update()
    {
        _rigidbody.angularVelocity = _angularVeloscity * GlobalProperty.GameSpeed;
        if (Time.time >= _delay)
        {
            _delay = Time.time + (_direction == 0 ? 1 : 5);
            _angularVeloscity = new Vector3(0, 0, _direction) * _speed;
            AngularVelosityZ = _direction * _speed;
            _speed = Random.Range(_minSpeed, _maxSpeed);
            _direction = Random.Range(-1, 2);
        }
    }
}
