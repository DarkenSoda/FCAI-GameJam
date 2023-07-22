using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSliding : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Ice>() == null) return;

        IsOnIce = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<Ice>() == null) return;

        IsOnIce = false;
    }

    public bool IsOnIce { get; private set; }
}
