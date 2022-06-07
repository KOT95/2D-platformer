using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        
        GetComponent<PlayerInput>().Moving += OnMove;
        GetComponent<PlayerInput>().Jumping += OnJump;
    }

    private void OnDisable()
    {
        GetComponent<PlayerInput>().Moving -= OnMove;
        GetComponent<PlayerInput>().Jumping -= OnJump;
    }

    private void OnMove(float horizontal)
    {
        _rigidbody2D.velocity = new Vector2(horizontal * walkSpeed, _rigidbody2D.velocity.y);
        _animator.SetBool("Walk", horizontal == 0 ? false : true);

        if (horizontal > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (horizontal < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void OnJump()
    {
        var collisionCount = _rigidbody2D.Cast(-transform.up, _results, 0.1f);

        if(collisionCount != 0)
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
}
