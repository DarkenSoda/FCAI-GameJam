using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Awake() {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("GameMusic");
        if (gameObjects.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
