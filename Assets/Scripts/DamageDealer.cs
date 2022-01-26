using UnityEngine;
using UnityEngine.Events;

public enum DamageType
{
    NORMAL,
    KNOCKING
}

public struct DamageInfo
{
    public int DamageAmount;
    
    public DamageType type;
    public float orientation;

    public DamageDealer Dealer;
}

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private int m_Damage = 1;
    
    [SerializeField]
    private DamageType m_DamageType = DamageType.NORMAL;
    
    public UnityEvent<bool, DamageInfo> OnObjectHit = new UnityEvent<bool, DamageInfo>();

    private bool m_IsDealingDamage = false;
    private double last_time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_IsDealingDamage = true;
        last_time = Time.timeAsDouble;

        DamageHandler handler = collision.GetComponent<DamageHandler>();
        bool applyDamage = handler != null;

        Debug.Log($"Deal damage to {collision.name}");

        DamageInfo damageInfo = new DamageInfo()
        {
            DamageAmount = m_Damage,
            type = m_DamageType,
            orientation = transform.forward.z,
            Dealer = this
        };

        if (applyDamage)
        {
            handler.ApplyDamage(damageInfo);
        }

        OnObjectHit.Invoke(applyDamage, damageInfo);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_IsDealingDamage = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.timeAsDouble - last_time > 0.5) { 
            OnTriggerEnter2D(collision);
        }
    }

}
