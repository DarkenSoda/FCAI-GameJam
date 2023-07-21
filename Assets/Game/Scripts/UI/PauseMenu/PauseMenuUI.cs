using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour {
    public Button continueBtn;
    public Button settingsBtn;
    public Button mainMenuBtn;

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
