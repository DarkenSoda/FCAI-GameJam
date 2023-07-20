using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public event EventHandler OnSeasonChange;

    public bool IsChangingSeason{ get; private set; }

    private void Awake() {
        if (Instance == null) Instance = this;
    }

    private void Start() {
        GameInput.Instance.OnPlayerChangeEnvironment += OnPlayerChangeEnvironment;
    }

    private void OnDestroy() {
        GameInput.Instance.OnPlayerChangeEnvironment -= OnPlayerChangeEnvironment;
    }

    private void OnPlayerChangeEnvironment(object sender, EventArgs e) {
        if(IsChangingSeason) return;

        IsChangingSeason = true;
        OnSeasonChange?.Invoke(this, EventArgs.Empty);
    }
}
