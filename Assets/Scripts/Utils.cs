using UnityEngine;

public static class VectorExtensions {
  public static Vector2 InvertX(this Vector2 v) {
    return new Vector2(-v.x, v.y);
  }

  public static Vector2 InvertY(this Vector2 v) {
    return new Vector2(v.x, -v.y);
  }

  public static Vector2 ClampMinMaxMagnitude(this Vector2 v, float min, float max) {
    var sqrMagnitude = v.sqrMagnitude;

    if (sqrMagnitude < min * min) {
      return min * v.normalized;
    }

    if (sqrMagnitude > max * max) {
      return Vector2.ClampMagnitude(v, max);
    }

    return v;
  }
}