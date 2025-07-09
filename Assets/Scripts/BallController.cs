using UnityEngine;

public class BallController : MonoBehaviour {
    [Header("Props")]
    public float minSpeed = 6f;
    public float maxSpeed = 12f;
    public float rocketVelocityImpact = 20f;

    private Rigidbody2D rb;
    private Vector2 currentVelocity;

    void Update() {
        Debug.Log($"speed = {currentVelocity.magnitude}");
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();

        var startVelocity = minSpeed * new Vector2(1, Random.Range(-1, 1)).normalized;
        UpdateVelocity(startVelocity);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject other = collision.gameObject;

        if (other.CompareTag(Tags.Wall)) {
            OnWallCollision();
        } else if (other.CompareTag(Tags.Racket)) {
            OnRacketCollision(other);
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

    void OnRacketCollision(GameObject racket) {
        var controller = racket.GetComponent<RacketController>();
        if (controller == null) {
            Debug.LogError("BallController.OnRacketCollision: RacketController is missing on racket");
            return;
        }

        var newVelocity = currentVelocity.InvertX();
        newVelocity += controller.Velocity * rocketVelocityImpact;

        UpdateVelocity(newVelocity);
    }

    void EnemyGateTriggered() {
        Debug.Log("You won");
    }

    void PlayerGateTriggered() {
        Debug.Log("Game ove");
    }

    void UpdateVelocity(Vector2 velocity) {
        var newVelocity = velocity.ClampMinMaxMagnitude(minSpeed, maxSpeed);

        currentVelocity = newVelocity;
        rb.linearVelocity = newVelocity;
    }
}
