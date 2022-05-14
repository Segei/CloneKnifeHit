using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody))]
public class KnifeMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 10;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GlobalProperty.Lose.AddListener(
            () =>
            {
                if (!_rigidbody.useGravity)
                {
                    Stop();
                }
            }
            );
    }


    public void Move(CallbackContext context)
    {
        _rigidbody.AddForce(Vector3.up * _speed, ForceMode.Impulse);
    }
    public void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
    }
    public void Down()
    {
        _rigidbody.useGravity = true;
        _rigidbody.velocity = Vector3.zero;
    }
}
