using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;

    void LateUpdate()
    {
        if (playerTransform != null)
            transform.position = playerTransform.position + offset;
        }
    }
