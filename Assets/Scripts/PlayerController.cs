using UnityEngine;

public class PlayerController : MonoBehaviour {
  private RocketController controller;

  void Start() {
    controller = GetComponent<RocketController>();
  }

  void Update() {
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    controller.SetTargetPositionY(mousePosition.y);
  }
}
