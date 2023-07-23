using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenuUI : MonoBehaviour {
    public TMP_Dropdown screenResolution;

    public TextMeshProUGUI masterAudioText;
    public Slider masterAudioSlider;
    public Button goBackButton;

    private void Start() {
        LoadValues();
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void SetResolution() {
        switch (screenResolution.value) {
            case 0:
                Screen.SetResolution(640, 360, true);
                break;
            case 1:
                Screen.SetResolution(800, 600, true);
                break;
            case 2:
                Screen.SetResolution(1280, 720, true);
                break;
            case 3:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }

    public void MasterAudioChange() {
        PlayerPrefs.SetFloat("MusicVolume", masterAudioSlider.value);
        LoadValues();
    }

    private void LoadValues() {
        float volume = 5f;
        if (PlayerPrefs.HasKey("MusicVolume")) {
            volume = PlayerPrefs.GetFloat("MusicVolume");
        }
        masterAudioSlider.value = volume;
        masterAudioText.text = volume.ToString();
        AudioListener.volume = volume / 5;
    }
}
