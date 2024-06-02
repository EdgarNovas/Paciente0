using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Graphics : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;

    void Start()
    {
        // Get available resolutions
        resolutionDropdown.captionText.fontSize = 10;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        

        // Fill resolution dropdown with options
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolution.ToString()));
        }

        // Set default resolution to current screen resolution
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
                
            }
        }
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        
        
        // Fill quality dropdown with options
        string[] qualityNames = QualitySettings.names;
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(new System.Collections.Generic.List<string>(qualityNames));

        // Set default quality level to current quality level
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
