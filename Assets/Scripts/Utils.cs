
using UnityEngine;

public static class VectorExtensions {
  public static Vector2 InvertX(this Vector2 v) {
    return new Vector2(-v.x, v.y);
  }

  public static Vector2 InvertY(this Vector2 v) {
    return new Vector2(v.x, -v.y);
  }
}