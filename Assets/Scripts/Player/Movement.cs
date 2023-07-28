using UnityEngine;

namespace Player
{
    // Summary: This Unity script controls the movement and animation of a 2D character. It utilizes Rigidbody2D for physics-based movement and Animator for character animations.

    public class Movement : MonoBehaviour
    {
      [SerializeField] private Rigidbody2D rb;
          [SerializeField] private Animator animator;
          [SerializeField] private float speed;
      
          private Vector2 _moveDirection;
          private static readonly int Walk = Animator.StringToHash("Walk");
      
          private void Update()
          {
              // Get input for player movement
              var xAxis = Input.GetAxisRaw("Horizontal");
              var yAxis = Input.GetAxisRaw("Vertical");
              _moveDirection = new Vector2(xAxis, yAxis).normalized;
              animator.SetBool(Walk, _moveDirection != Vector2.zero);
      
              // Rotate the player's GameObject based on input direction
              if (_moveDirection == Vector2.zero) return;
              // var angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
              gameObject.transform.rotation = Quaternion.Euler(0, (_moveDirection.x > 0) ? 0 : 180, 0);
          }
      
          private void FixedUpdate()
          {
              // Move the player using rigidbody physics
              rb.MovePosition(rb.position + _moveDirection * (speed * Time.fixedDeltaTime));
          }
    }
}
    

