using System;
using UnityEngine;
using TMPro;
public class LevelCompleteCanvasUI : MonoBehaviour {
    [SerializeField] private int nextLevelNumber;
    [SerializeField] private LevelCompleteUI nextLevelUI;
    [SerializeField] private LastLevelCompleteUI lastLevelUI;
    [SerializeField] private TextMeshProUGUI lastSnowBall;
    [SerializeField] private TextMeshProUGUI snowBall;

    private void Start() {
        GameManager.Instance.OnLevelComplete += LevelCompleted;
        if (nextLevelUI.gameObject.activeInHierarchy) nextLevelUI.Hide();
        if (lastLevelUI.gameObject.activeInHierarchy) lastLevelUI.Hide();
    }

    private void OnDestroy() {
        GameManager.Instance.OnLevelComplete -= LevelCompleted;
    }

    private void LevelCompleted(object sender, EventArgs e) {
        snowBall.text = $"Collected Snow Balls: {GameManager.Instance.collectedSnowBall}/{GameManager.Instance.availableSnowBalls}";
        lastSnowBall.text = $"Collected Snow Balls: {GameManager.Instance.collectedSnowBall}/{GameManager.Instance.availableSnowBalls}";
        Loader.SaveLastLevelReached(nextLevelNumber);
        if (Loader.IsLastLevel) {
            lastLevelUI.Show();
        } else {
            nextLevelUI.Show();
            nextLevelUI.SetLevel(nextLevelNumber);
        }
    }
}
