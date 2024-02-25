using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;
    public float cameraSpeed = 2.0f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        player.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        transform.LookAt(player.position);
    }
}
