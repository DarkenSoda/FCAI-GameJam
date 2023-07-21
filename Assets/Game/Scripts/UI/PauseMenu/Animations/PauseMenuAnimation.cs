using System.Collections;
using UnityEngine;

public class PauseMenuAnimation : UIShowHide {
    public void HideAnimation() {
        GetComponent<Animator>().SetTrigger("Hide");
    }
}
