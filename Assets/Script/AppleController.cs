using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class AppleController : MonoBehaviour, IController
{

    [SerializeField] private GameObject _halfApllePart1;
    [SerializeField] private GameObject _halfApllePart2;
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();
    private List<GameObject> _parts = new List<GameObject>();
    public void HitOnMe()
    {
        GlobalProperty.Sounds.PlayAppleHit();
        GlobalProperty.AppleCounter.AddApple();
        SpavnHalfApple(_halfApllePart1, 1);
        SpavnHalfApple(_halfApllePart2, -1);
        Destroy(gameObject);
    }

    private void SpavnHalfApple(GameObject halfAple, float direction)
    {
        _parts.Add(Instantiate(halfAple, gameObject.transform.position, gameObject.transform.rotation));
        _rigidbodies.Add(_parts.Last().AddComponent<Rigidbody>());
        _rigidbodies.Last().isKinematic = false;
        _rigidbodies.Last().useGravity = true;
        _rigidbodies.Last().AddForce(new Vector3(LogController.AngularVelosityZ * direction, 0, 0), ForceMode.Impulse);
    }
}
