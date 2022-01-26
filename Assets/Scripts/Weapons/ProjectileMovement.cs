using UnityEngine;

public class ProjectileMovement : APooledObject
{
    [SerializeField]
    private float m_MovementSpeed = 10f;

    [SerializeField]
    private Rigidbody2D m_Rigidbody = null;

    private void FixedUpdate()
    {
        Vector3 targetPosition = m_Rigidbody.position + new Vector2(-transform.forward.z, transform.forward.y)  * m_MovementSpeed * Time.fixedDeltaTime;
        m_Rigidbody.MovePosition(targetPosition);
    }

    public void HandleObjectHit(bool applyDamage, DamageInfo damgeInfo)
    {
        Debug.Log("PROJECTILE HIT");

        ReturnToPool();
    }

    public void Restart(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;

        gameObject.SetActive(true);
    }
}