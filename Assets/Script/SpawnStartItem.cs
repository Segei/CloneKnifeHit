using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnStartItem : MonoBehaviour
{
    [SerializeField] private GameObject _apple;
    [SerializeField] private GameObject _knife;
    [SerializeField] private GameObject _log;
    [SerializeField] private float _z;
    [SerializeField] private int _minimalAngle = 15;
    private float _radius;
    private Vector3 _positionSpawn = new Vector3(0, 100, 0);
    private List<GameObject> _items = new List<GameObject>();
    private void Start()
    {
        _radius = _log.GetComponent<CapsuleCollider>().radius;
        GlobalProperty.GameSpeed = 1;
        int angle = 0;
        List<int> positions = new List<int>();
        bool fixposition;
        Vector3 position;
        for (int i = 0; i < Random.Range(0, 4); i++)
        {
            _items.Add(Instantiate(_apple));
            _items.Last().transform.position = _positionSpawn;
            _items.Last().name = _items.Last().name + i;
        }
        for (int i = 0; i < Random.Range(0, 4); i++)
        {
            _items.Add(Instantiate(_knife));
            _items.Last().transform.position = _positionSpawn;
            _items.Last().name = _items.Last().name + i;
        }
        foreach (GameObject item in _items)
        {
            fixposition = false;
            while (!fixposition)
            {
                angle = Random.Range(0, (int)(360/ _minimalAngle)) * _minimalAngle;
                position = GetPosition(angle);
                if (positions.Any(itemPos => itemPos == angle))
                {
                    continue;
                }
                fixposition = true;
                positions.Add(angle);
                item.transform.SetParent(_log.transform);
                item.transform.localPosition = position;
                item.transform.rotation = Quaternion.FromToRotation(Vector3.up * -1, _log.transform.position - item.transform.position);
            }
        }
    }

    private Vector3 GetPosition(int angle)
    {
        Vector3 position = new Vector3
        {
            y = Mathf.Sin(angle) * _radius,
            x = Mathf.Cos(angle) * _radius,
            z = 0
        };
        return position;
    }
}
