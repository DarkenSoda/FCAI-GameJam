using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndlineReached : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Player>() == null) return;

        GameManager.Instance.LevelCompleted();
    }
}
