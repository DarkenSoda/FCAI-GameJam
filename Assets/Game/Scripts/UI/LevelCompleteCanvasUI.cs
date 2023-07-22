using System;
using UnityEngine;

public class LevelCompleteCanvasUI : MonoBehaviour {
    [SerializeField] private int nextLevelNumber;

    [SerializeField] int availableSnowBalls;
    private int collectedSnowBall = 0;
    [SerializeField] private LevelCompleteUI nextLevelUI;
    [SerializeField] private LastLevelCompleteUI lastLevelUI;
    [SerializeField] private Player player;

    private void Start() {
        GameManager.Instance.OnLevelComplete += LevelCompleted;
        player.OnSnowCollection += SnowBallCollection;
        if (nextLevelUI.gameObject.activeInHierarchy) nextLevelUI.Hide();
        if (lastLevelUI.gameObject.activeInHierarchy) lastLevelUI.Hide();
    }

    private void OnDestroy() {
        GameManager.Instance.OnLevelComplete -= LevelCompleted;
        player.OnSnowCollection -= SnowBallCollection;
    }

    private void SnowBallCollection(object sender, EventArgs e) {
        collectedSnowBall++;
        Debug.Log(collectedSnowBall);
    }

    private void LevelCompleted(object sender, EventArgs e) {
        collectedSnowBall = 0;
        Loader.SaveLastLevelReached(nextLevelNumber);
        if (Loader.IsLastLevel) {
            lastLevelUI.Show();
        } else {
            nextLevelUI.Show();
            nextLevelUI.SetLevel(nextLevelNumber);
        }
    }
}
