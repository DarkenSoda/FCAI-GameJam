using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteUI : MonoBehaviour {
    [SerializeField] private Button nextLevelBtn;
    [SerializeField] private Button mainMenuBtn;

    private void Start() {
        nextLevelBtn.onClick.AddListener(() => {

        });
        mainMenuBtn.onClick.AddListener(() => {

        });
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
