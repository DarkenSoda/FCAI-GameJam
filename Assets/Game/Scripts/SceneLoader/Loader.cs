using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader {
    public static int lastLevelReachedIndex { get; private set; }
    public static bool IsLastLevel { get; private set; } = false;

    // change index logic according to your build settings
    public static void LoadLevel(int index) {
        // considering all level scenes starts from 2 till last index in build
        index += 1;

        if (index > SceneManager.sceneCountInBuildSettings - 1 || index < 0) {
            return;
        }
        // PlayTransition Animation
        GameManager.Instance.StartCoroutine(Loader.SceneLoading(index));
    }

    // if you don't have level transition animation, remove the couroutine and animator code.
    private static IEnumerator SceneLoading(int index) {
        GameManager.Instance.GetComponent<Animator>().SetTrigger("LevelTransition");

        yield return new WaitForSecondsRealtime(2f);

        // Load Scene
        SceneManager.LoadScene(index);
        SceneManager.LoadScene(1, LoadSceneMode.Additive); // load Options scene considering it is index 1


        // Check if Last Level
        if (index == SceneManager.sceneCountInBuildSettings - 1) {
            IsLastLevel = true;
        }
    }

    // if you don't have level transition animation, change the coroutine to a void function and remove animator code.
    private static IEnumerator MainMenuLoading(int index) {
        GameManager.Instance.GetComponent<Animator>().SetTrigger("LevelTransition");
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(index);
    }

    public static void StartNewGame() {
        SaveLastLevelReached(1);
        IsLastLevel = false;
        LoadLevel(lastLevelReachedIndex);
    }

    // Considering that the menu scene is index 0
    public static void LoadMainMenu() {
        GameManager.Instance.StartCoroutine(MainMenuLoading(0));
    }

    public static void SaveLastLevelReached(int index) {
        PlayerPrefs.SetInt("LastLevelReached", index);
        PlayerPrefs.Save();
        lastLevelReachedIndex = index;
    }
    public static void LoadLast() {
        lastLevelReachedIndex = PlayerPrefs.GetInt("LastLevelReached");
    }

    public static void LoadLastLevelReached() {
        LoadLevel(lastLevelReachedIndex);
    }
}