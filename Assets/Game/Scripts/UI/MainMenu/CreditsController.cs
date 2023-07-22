using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CreditsController : UIShowHide
{
    private float time;
    [SerializeField] private Transform credits;
    [SerializeField] private float creditsSpeed;
    [SerializeField] private float waitTime = 10f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform creditsPosition;


    private void OnEnable() {
        time = 0;
    }
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
        time += Time.deltaTime;
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
    private void EndCredits()
    {
        if (time < waitTime) {
            return;
        }   

        // End credits scene
        OnStopCredits(this, EventArgs.Empty);
    }
}
