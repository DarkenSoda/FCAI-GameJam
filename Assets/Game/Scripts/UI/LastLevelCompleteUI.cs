using UnityEngine;
using UnityEngine.UI;

public class LastLevelCompleteUI : MonoBehaviour {
    [SerializeField] private Button playAgainBtn;
    [SerializeField] private Button mainMenuBtn;

    private void Start() {
        playAgainBtn.onClick.AddListener(() => {
            Loader.StartNewGame();
        });
        mainMenuBtn.onClick.AddListener(() => {
            Loader.LoadMainMenu();
        });
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
