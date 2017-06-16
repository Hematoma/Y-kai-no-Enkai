using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour 
{
    private BoxCollider2D cameraBox;
    private Transform player;

    void Start()
    {
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        AspectRatioBoxChange();
        FollowPlayer();
    }

    void AspectRatioBoxChange()
    {
        float h = 2 * Camera.main.orthographicSize; // consigue altura
        cameraBox.size = new Vector2(h * Camera.main.aspect, h);
    }

    void FollowPlayer()
    {
        GameObject boundary = GameObject.FindGameObjectWithTag("activeBoundary");
        if (boundary)
        {
            transform.position = new Vector3 (Mathf.Clamp(player.position.x, boundary.GetComponent<BoxCollider2D> ().bounds.min.x + cameraBox.size.x / 2, boundary.GetComponent<BoxCollider2D> ().bounds.max.x - cameraBox.size.x / 2),
                                              Mathf.Clamp(player.position.y, boundary.GetComponent<BoxCollider2D> ().bounds.min.y + cameraBox.size.y / 2, boundary.GetComponent<BoxCollider2D> ().bounds.max.y - cameraBox.size.y / 2),
                                              transform.position.z);
        }
    }
}
