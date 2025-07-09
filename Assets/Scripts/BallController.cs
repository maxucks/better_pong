using UnityEngine;

public class BallController : MonoBehaviour {
    [Header("Props")]
    public float speed = 6;

    private Rigidbody2D rb;
    private Vector2 currentVelocity;

    void Start() {
        rb = GetComponent<Rigidbody2D>();

        var startVelocity = speed * new Vector2(1, Random.Range(-1, 1)).normalized;
        UpdateVelocity(startVelocity);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject other = collision.gameObject;

        if (other.CompareTag(Tags.Wall)) {
            OnWallCollision();
        } else if (other.CompareTag(Tags.Rocket)) {
            OnRocketCollision(other);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject other = collider.gameObject;

        if (other.CompareTag(Tags.EnemyGate)) {
            EnemyGateTriggered();
        } else if (other.CompareTag(Tags.PlayerGate)) {
            PlayerGateTriggered();
        }

        // TODO: remove
        transform.position = Vector3.zero;
    }

    void OnWallCollision() {
        var newVelocity = currentVelocity.InvertY();
        UpdateVelocity(newVelocity);
    }

    void OnRocketCollision(GameObject rocket) {
        var controller = rocket.GetComponent<RocketController>();
        if (controller == null) {
            Debug.LogError("BallController.OnRocketCollision: RocketController is missing on rocket");
            return;
        }

        var newVelocity = currentVelocity.InvertX();
        newVelocity += controller.Velocity;
        Debug.Log($"{currentVelocity} + {controller.Velocity} => {newVelocity}");

        UpdateVelocity(newVelocity);
    }

    void EnemyGateTriggered() {
        Debug.Log("You won");
    }

    void PlayerGateTriggered() {
        Debug.Log("Game ove");
    }

    void UpdateVelocity(Vector2 velocity) {
        currentVelocity = velocity;
        rb.linearVelocity = velocity;
    }
}
