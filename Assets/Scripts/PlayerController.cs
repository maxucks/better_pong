using UnityEngine;

public class PlayerController : MonoBehaviour {
  private RacketController controller;

  void Start() {
    controller = GetComponent<RacketController>();
  }

  void Update() {
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    controller.SetTargetPositionY(mousePosition.y);
  }
}
