using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI personRescued;
    [SerializeField] TextMeshProUGUI health;

    private void Awake()
    {
        personRescued.text = GameManager.Instance.rescuedPeople.ToString();
    }


}
