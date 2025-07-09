using Unity.Mathematics;
using UnityEngine;

public class RacketController : MonoBehaviour {
  [Header("Props")]
  public float smoothness = .1f;
  public float maxDeltaY = .5f;

  private Rigidbody2D rb;

  private float targetY;
  private float nextY;

  private Vector2 velocity;
  public Vector2 Velocity => velocity;

  public void SetTargetPositionY(float y) => targetY = y;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    UpdateNextPosition();
    Move(nextY);
  }

  void UpdateNextPosition() {
    var lerpedPositionY = math.lerp(rb.position.y, targetY, smoothness);

    var deltaY = lerpedPositionY - rb.position.y;
    deltaY = math.clamp(deltaY, -maxDeltaY, maxDeltaY);

    nextY = rb.position.y + deltaY;
    velocity = new Vector2(0, deltaY);
  }

  void Move(float y) {
    var position = new Vector2(0, y);
    rb.MovePosition(position);
  }
}
