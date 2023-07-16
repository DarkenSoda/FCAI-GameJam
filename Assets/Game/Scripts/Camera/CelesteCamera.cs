using UnityEngine;
using Cinemachine;

public class CelesteCamera : MonoBehaviour {
    private CinemachineVirtualCamera cinemachine;

    private void Start() {
        cinemachine = GetComponentInChildren<CinemachineVirtualCamera>();

        cinemachine.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Player>() == null) return;

        cinemachine.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<Player>() == null) return;
        
        cinemachine.gameObject.SetActive(false);
    }
}
