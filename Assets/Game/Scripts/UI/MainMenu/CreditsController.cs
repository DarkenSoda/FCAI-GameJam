using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CreditsController : UIShowHide
{
    [SerializeField] private GameObject endGameObject;
    [SerializeField] private Transform endYPosition;
    [SerializeField] private Transform credits;
    [SerializeField] private float creditsSpeed;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform creditsPosition;


    private void OnEnable()
    {
        gameInput.OnGamePaused += OnStopCredits;
        gameInput.OnMouseClicked += OnStopCredits;
    }
    private void OnDisable()
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
        GetComponentInParent<CanvasManager>().ShowButtons();
        Hide();
    }

    public override void Show() {
        base.Show();
        credits.position = creditsPosition.position;
    }
    public void EndCredits()
    {
        if (endGameObject.transform.position.y < endYPosition.position.y) {
            return;
        }
          // End credits scene
        OnStopCredits(this, EventArgs.Empty);
    }
}
