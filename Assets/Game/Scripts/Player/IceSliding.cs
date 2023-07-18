using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSliding : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<Ice>() == null) return;

        IsOnIce = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.GetComponent<Ice>() == null) return;

        IsOnIce = false;
    }

    public bool IsOnIce { get; private set; }
}
