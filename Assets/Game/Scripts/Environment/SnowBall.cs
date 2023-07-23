using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour {
    public static event EventHandler OnSnowCollection;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            this.gameObject.SetActive(false);
            SnowCollected();
            Destroy(this.gameObject, 2f);
        }
    }
    private void SnowCollected() {
        OnSnowCollection?.Invoke(this, EventArgs.Empty);
    }

}
