using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicBackground : MonoBehaviour
{

    [SerializeField] private float backgroundSpeed = .03f;
    [SerializeField] private RawImage backgroundImage;

    private void Start() {
        backgroundImage = GetComponentInChildren<RawImage>();
    }

    private void Update() {
        backgroundImage.uvRect = new Rect(backgroundImage.uvRect.position + 
                new Vector2(1f, 0f) * backgroundSpeed * Time.deltaTime, backgroundImage.uvRect.size);
    }
}
