using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    public event EventHandler OnSeasonChangeStart;
    public event EventHandler OnSeasonChange;
    public event EventHandler OnLevelComplete;

    public bool IsChangingSeason { get; private set; }
    public bool IsLevelCompleted { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    private void Start() {
        GameInput.Instance.OnPlayerChangeEnvironment += OnPlayerChangeEnvironment;
    }

    private void OnDestroy() {
        GameInput.Instance.OnPlayerChangeEnvironment -= OnPlayerChangeEnvironment;
    }

    private void OnPlayerChangeEnvironment(object sender, EventArgs e) {
        if (IsChangingSeason || IsLevelCompleted) return;
        if (!Player.Instance.IsGrounded) return;

        IsChangingSeason = true;
        OnSeasonChangeStart?.Invoke(this, EventArgs.Empty);
        GetComponent<Animator>().SetTrigger("Start");
    }

    public void ChangeSeason() {
        OnSeasonChange?.Invoke(this, EventArgs.Empty);
    }

    public void EndChangeSeason() {
        IsChangingSeason = false;
    }

    public void LevelCompleted() {
        IsLevelCompleted = true;
        OnLevelComplete?.Invoke(this, EventArgs.Empty);
    }
}
