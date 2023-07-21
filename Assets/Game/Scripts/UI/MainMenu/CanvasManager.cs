using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsManager;
    [SerializeField] private SettingsMenuUI settingsMenuUI;
    [SerializeField] private ButtonsHandler buttons;
    void Start()
    {
        if (settingsManager.activeInHierarchy) { 
            settingsManager.SetActive(false);
        }
        settingsMenuUI.goBackButton.onClick.AddListener(() =>{ 
            settingsManager.SetActive(false);
            buttons.Show();
        });
        buttons.optionsButton.onClick.AddListener(() => {
            buttons.Hide();
            settingsManager.SetActive(true);
        });
    }
}
