using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader {
    private static int lastLevelReachedIndex;
    public static bool IsLastLevel = false;

    public static void LoadLevel(int index) {
        index += 1;
        
        if (index > SceneManager.sceneCountInBuildSettings - 1 || index < 0) {
            return;
        }
        // PlayTransition Animation
        GameManager.Instance.StartCoroutine(Loader.SceneLoading(index));
    }

    private static IEnumerator SceneLoading(int index) {
        GameManager.Instance.GetComponent<Animator>().SetTrigger("LevelTransition");

        yield return new WaitForSecondsRealtime(2f);

        // Load Scene
        SceneManager.LoadScene(index);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);


        // Check if Last Level
        if (index == SceneManager.sceneCountInBuildSettings - 1) {
            IsLastLevel = true;
        }
    }

    public static void StartNewGame() {
        SaveLastLevelReached(1);
        IsLastLevel = false;
        LoadLevel(lastLevelReachedIndex);
    }

    public static void LoadMainMenu() {
        LoadLevel(-1);
    }

    public static void SaveLastLevelReached(int index) {
        PlayerPrefs.SetInt("LastLevelReached", index);
        PlayerPrefs.Save();
        lastLevelReachedIndex = index;
    }

    public static void LoadLastLevelReached() {
        lastLevelReachedIndex = PlayerPrefs.GetInt("LastLevelReached");
        LoadLevel(lastLevelReachedIndex);
    }
}