using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalidadImagen : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int quality;

    void Start()
    {
        quality = PlayerPrefs.GetInt("numberOfQuality", 2);
        dropdown.value = quality;
        AdjustQuality();
    }


    public void AdjustQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numberOfQuality", dropdown.value);
        quality = dropdown.value;
    }
}
