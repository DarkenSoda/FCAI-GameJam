using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public event EventHandler OnSeasonChangeStart;
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
        if(!Player.Instance.IsGrounded) return;
        if(IsChangingSeason) return;

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
}
