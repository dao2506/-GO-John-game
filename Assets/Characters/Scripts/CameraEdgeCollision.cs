using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEdgeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        AddColliderOnCamera();
    }

    public void AddColliderOnCamera()
    {
        Camera camera = Camera.main;

        var edgeCollider = gameObject.GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : gameObject.GetComponent<EdgeCollider2D>();

        var leftBottom = (Vector2)camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        var leftTop = (Vector2)camera.ScreenToWorldPoint(new Vector3(0, camera.pixelHeight, camera.nearClipPlane));
        var rightTop = (Vector2)camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, camera.nearClipPlane));
        var rightBottom = (Vector2)camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, 0, camera.nearClipPlane));

        var edgePoints = new[] { leftBottom, leftTop, rightTop, rightBottom};

        edgeCollider.points = edgePoints;
    }
}
