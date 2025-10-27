using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider slider;

    public void UpdateValue(int value)
    {
        if (slider.value != value)
            slider.value = value;
    }
}
