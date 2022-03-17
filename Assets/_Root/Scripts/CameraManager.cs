using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetTransform;
    public float cameraFollowSpeed = 0.2f;

    private Vector3 cameraFollowVelocity = Vector3.zero;

    private void Awake()
    {
        targetTransform = FindObjectOfType<PlayerManager>().transform;
    }

    public void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;
    }
}
