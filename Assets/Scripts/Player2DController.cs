using UnityEngine;

public class Player2DController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    [SerializeField]
    private float m_KnockoutVerticalForce = 0.5f;

    [SerializeField]
    private float m_KnockoutHorizontalForce = 0.5f;

    private float m_KnockOrientation = 0;

    public Animator animator;

    [SerializeField]
    private Weapon m_Weapon = null;

    private Rigidbody2D _rigidBody;
    private float orientation = -1;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void CheckForShoot()
    {
        if (Input.GetButton("Fire1"))
        {
            m_Weapon.Fire();
        }
    }

    void Update()
    {
        _rigidBody.AddForce(Vector2.zero);
        
        CheckForShoot();

        if (m_KnockOrientation != 0f)
        {
            _rigidBody.AddForce(new Vector2(m_KnockOrientation * m_KnockoutHorizontalForce, JumpForce * m_KnockoutVerticalForce), ForceMode2D.Impulse);
            m_KnockOrientation = 0f;

            return;
        }

        var movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        animator.SetFloat("speed", Mathf.Abs(movement * Time.deltaTime * MovementSpeed));

        // Manage the rotation of the character when changing directions.
        if (movement != 0)
        {
            if (Mathf.Sign(movement) != orientation)
            {
                transform.Rotate(0, 180, 0, Space.Self);
                orientation = Mathf.Sign(movement);
            }
        } 

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidBody.velocity.y) < 0.001f)
        {
            _rigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("jump", true);
        }
        else if (Mathf.Abs(_rigidBody.velocity.y) < 0.001f) {
            OnLanding();
        }
    }

    public void OnLanding()
    {
        animator.SetBool("jump", false);
    }

    public void OnKnocked(float orientation)
    {
        m_KnockOrientation = -orientation;
    }
}
