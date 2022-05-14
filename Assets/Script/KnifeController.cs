using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(KnifeMove))]
public class KnifeController : MonoBehaviour, IController
{

    private Rigidbody _rigidbody;
    [SerializeField] private KnifeMove _move;
    public KnifeMove Move => _move;
    public UnityEvent Lose;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _move = GetComponent<KnifeMove>();
        Lose.AddListener(() => GlobalProperty.Lose?.Invoke());
    }
    public void HitOnMe()
    {
        GlobalProperty.Sounds.PlayKnifeHit();
        gameObject.transform.SetParent(null);
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(new Vector3(LogController.AngularVelosityZ, 0), ForceMode.Impulse);
        Lose?.Invoke();
    }

}
