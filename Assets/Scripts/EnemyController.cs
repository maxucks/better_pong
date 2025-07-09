using UnityEngine;

public class EnemyController : MonoBehaviour {
  [Header("Props")]
  public GameObject ball;

  private RacketController controller;

  void Start() {
    controller = GetComponent<RacketController>();
  }

  void Update() {
    controller.SetTargetPositionY(ball.transform.position.y);
  }
}
