using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundMovement : MonoBehaviour {
    [SerializeField] private Player player;


    [SerializeField] private float backgroundSpeed;
    [SerializeField] private RawImage backgroundImage;


    private void Update() {
        float horizontal = player.GetVelocity().x;

        backgroundImage.uvRect = new Rect(backgroundImage.uvRect.position + 
                new Vector2(horizontal, 0f) * backgroundSpeed * Time.deltaTime, backgroundImage.uvRect.size);
    }
}
