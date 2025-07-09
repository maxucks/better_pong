using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  public static GameManager Instance { get; private set; }

  void Awake() {
    if (Instance != null && Instance != this) {
      Destroy(gameObject);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
  }

  public void GameOver(bool win) {
    ResetScene();
    StartCoroutine(PauseFor(1));
  }

  void ResetScene() {
    Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.name);
  }

  IEnumerator PauseFor(float seconds) {
    Time.timeScale = 0f;
    yield return new WaitForSecondsRealtime(seconds);
    Time.timeScale = 1f;
  }
}
