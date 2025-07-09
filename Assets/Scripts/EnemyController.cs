using UnityEngine;

public class EnemyController : MonoBehaviour {
  [Header("Props")]
  public GameObject ball;

  private RacketController controller;
  private BallController ballController;

  void Start() {
    controller = GetComponent<RacketController>();
    ballController = ball.GetComponent<BallController>();
  }

  void Update() {
    var hit = Physics2D.Raycast(ball.transform.position, ballController.currentVelocity, 10f);

    if (hit.collider != null) {
      controller.SetTargetPositionY(hit.point.y);
    } else {
      controller.SetTargetPositionY(ball.transform.position.y);
    }
  }
}
