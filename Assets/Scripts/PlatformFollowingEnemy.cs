using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollowingEnemy : MonoBehaviour
{
    [SerializeField]
    private LayerMask platformLayerMask;

    [SerializeField]
    private BoxCollider2D boxCollider2d = null;

    [SerializeField]
    private float movementSpeed = 6f;

    private bool stuckOnWall = false;
    private int orientation = -1;
    private bool wasRotated = false;

    public void FixedUpdate()
    {
        if (!IsGrounded() || stuckOnWall)
        {
            if (!wasRotated || stuckOnWall)
            {
                orientation *= -1;
                transform.Rotate(new Vector3(0, 180, 0));
                stuckOnWall = false;
            }
            
            wasRotated = true;
        }
        else
        {
            wasRotated = false;
        }

        transform.position += new Vector3(orientation, 0, 0) * Time.deltaTime * movementSpeed;
    }

    private bool IsGrounded()
    {
        float extraHeightText = 0.5f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText, platformLayerMask);

        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !wasRotated)
        {
            stuckOnWall = true;
        }
    }
}
