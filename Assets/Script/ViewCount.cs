using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void updateCount(int count)
    {
        _text.text = count.ToString();
    }
}
