using UnityEngine;

namespace Camera
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private Transform target;             // The target to follow (player)
        [SerializeField] private float smoothSpeed = 0.125f;   // The speed at which the camera follows the target
        [SerializeField] private Vector3 offset;               // The offset from the target's position

        private void Awake()
        {
            transform.position = target.transform.position;
        }

        private void LateUpdate()
        {
            // Calculate the desired position of the camera
            var desiredPosition = target.position + offset;

            // Smoothly move the camera towards the desired position
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Set the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}