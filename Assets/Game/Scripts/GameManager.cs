using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int availableSnowBalls;
    public int collectedSnowBall{ get; private set; }
    public static GameManager Instance { get; private set; }

    public event EventHandler OnSeasonChangeStart;
    public event EventHandler OnSeasonChange;
    public event EventHandler OnLevelComplete;

    public bool IsGamePaused { get; private set; }
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
        collectedSnowBall = 0;
        IsGamePaused = true;
        GameInput.Instance.OnPlayerChangeEnvironment += OnPlayerChangeEnvironment;
        SnowBall.OnSnowCollection += OnSnowBallCollected;
    }
    private void Update() {
        if (IsGamePaused) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Cursor.visible) {  
            //if the cursor is Visible and unlocked and the game is not paused Hide it and lock it.
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnDestroy() {
        GameInput.Instance.OnPlayerChangeEnvironment -= OnPlayerChangeEnvironment;
        SnowBall.OnSnowCollection -= OnSnowBallCollected;
    }

    private void OnSnowBallCollected(object sender, EventArgs e) {
        collectedSnowBall++;

    }

    private void OnPlayerChangeEnvironment(object sender, EventArgs e) {
        if (Player.Instance == null) return;
        if (IsGamePaused || IsChangingSeason || IsLevelCompleted) return;
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

    public void SetIsGamePaused(bool value) {
        IsGamePaused = value;
    }
}
