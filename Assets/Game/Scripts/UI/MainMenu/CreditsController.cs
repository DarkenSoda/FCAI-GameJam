using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CreditsController : UIShowHide
{
    [SerializeField] private GameObject endGameObject;
    [SerializeField] private float endYPosition;
    [SerializeField] private Transform credits;
    [SerializeField] private float creditsSpeed;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform creditsPosition;


    private void Start()
    {
        gameInput.OnGamePaused += OnStopCredits;
        gameInput.OnMouseClicked += OnStopCredits;

        
    }
    private void OnDestroy()
    {
        gameInput.OnGamePaused -= OnStopCredits;
        gameInput.OnMouseClicked -= OnStopCredits;
    }

    private void Update()
    {
        credits.Translate(Vector2.up * creditsSpeed * Time.deltaTime, Space.World);
        EndCredits();
    }

    private void OnStopCredits(object sender, EventArgs e)
    {
        // End credits scene
        Hide();
    }

    public override void Show() {
        base.Show();
        credits.position = creditsPosition.position;
    }
    public void EndCredits()
    {
        if (endGameObject.transform.position.y < endYPosition) {
            return;
        }
          // End credits scene
        OnStopCredits(this, EventArgs.Empty);
    }
}
