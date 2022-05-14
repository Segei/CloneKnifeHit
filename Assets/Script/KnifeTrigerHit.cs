using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class KnifeTrigerHit : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public bool Active = false;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(!Active)
            return;
        var controller = other.GetComponent<IController>();
        if (controller != null)
        {
            try { Action((KnifeController)controller); } catch { }
            try { Action((AppleController)controller); } catch { }
            try { Action((LogController)controller); } catch { }
        }
    }
    private void Action(KnifeController controller)
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.useGravity = true;
        _rigidbody.AddForce(new Vector3(LogController.AngularVelosityZ * -1, 0), ForceMode.Impulse);
        controller.HitOnMe();
        Destroy(this);
    }
    private void Action(AppleController controller)
    {
        controller.HitOnMe();
    }
    private void Action(LogController controller)
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        _rigidbody.isKinematic = true;
        gameObject.transform.SetParent(controller.gameObject.transform);
        Active = false;
        controller.HitOnMe();
        Destroy(this);
    }



}
