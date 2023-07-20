using System;
using UnityEngine;

public class LevelCompleteCanvasUI : MonoBehaviour
{
    [SerializeField] private LevelCompleteUI UI;

    private void Start() {
        GameManager.Instance.OnLevelComplete += LevelCompleted;
        if(UI.gameObject.activeInHierarchy) UI.Hide();
    }

    private void OnDestroy() {
        GameManager.Instance.OnLevelComplete -= LevelCompleted;
    }

    private void LevelCompleted(object sender, EventArgs e) {
        UI.Show();
    }
}
