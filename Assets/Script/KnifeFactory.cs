using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Collider))]
public class KnifeFactory : MonoBehaviour
{
    private InputAndroid _input;
    private Collider _collider;
    [SerializeField] private GameObject _prefab;
    private bool _accsess = true;
    private bool _lose = false;


    private void Awake()
    {
        _input = new InputAndroid();
    }
    private void Start()
    {
        _collider = GetComponent<Collider>();
        GlobalProperty.KnifeController = NewKnife().GetComponent<KnifeController>();
        _input.Android.TouchPress.started += GlobalProperty.KnifeController.Move.Move;
        _input.Android.TouchPress.started += SetCounter;

        GlobalProperty.KnifeCounter.UpdateKnifeCount.AddListener((count) =>
        {
            if (_accsess)
            {
                _accsess = count > 0;
            }
        });
        GlobalProperty.Lose.AddListener(() =>
        {
            _lose = true;
            _input.Android.TouchPress.started -= SetCounter;
            GlobalProperty.GameSpeed = 0;
        });
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<KnifeController>(out var oldKnife))
        {
            oldKnife.gameObject.GetComponent<KnifeTrigerHit>().Active = true;
            if (!_accsess && !_lose)
            {
                return;
            }
            _input.Android.TouchPress.started -= GlobalProperty.KnifeController.Move.Move;
            NewKnife().GetComponent<KnifeController>();
            _input.Android.TouchPress.started += GlobalProperty.KnifeController.Move.Move;
            Physics.IgnoreCollision(_collider, other);
        }
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            _input.Android.TouchPress.WasPressedThisFrame();
        }
        
    }

    private GameObject NewKnife()
    {
        GameObject gameObject = Instantiate(_prefab);
        gameObject.transform.SetParent(null);
        gameObject.transform.position = this.gameObject.transform.position;
        gameObject.transform.rotation = Quaternion.Euler(180, 180, 0);
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        GlobalProperty.KnifeController = gameObject.GetComponent<KnifeController>();
        GlobalProperty.Lose.AddListener(() =>
        {
            _input.Android.TouchPress.started -= GlobalProperty.KnifeController.Move.Move;
        });
        rigidbody.useGravity = false;
        rigidbody.isKinematic = false;
        return gameObject;
    }
    private void SetCounter(CallbackContext obj)
    {
        GlobalProperty.KnifeCounter.RunKnife();
    }
}
