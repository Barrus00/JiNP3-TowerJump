using UnityEngine;
using UnityEngine.Events;

public class DestructibleObject : MonoBehaviour
{
    public UnityEvent OnDestroyed = new UnityEvent();
    public UnityEvent<float> OnKnocking = new UnityEvent<float>();

    [SerializeField]
    private int m_TotalHealthpoints = 1;

    private int m_CurrentHealthpoints = 0;

    private bool m_IsDestroyed = false;

    [Header("Healthbar")]
    [SerializeField]
    private Vector3 m_HealthbarOffset;

    [SerializeField]
    private Healthbar m_HealthbarPrefab = null;

    private Healthbar m_Healthbar = null;

    private void Awake()
    {
        Reset();

        if (m_Healthbar == null)
        {
            PrefabPool<Healthbar> healthbarPool = PoolManager.Instance.GetPool(m_HealthbarPrefab);

            m_Healthbar = healthbarPool.Get();
            m_Healthbar.Reset(transform, m_HealthbarOffset);
        }
    }

    public void ApplyDamage(DamageInfo damageInfo)
    {
        if (m_IsDestroyed)
        {
            return;
        }
        
        m_CurrentHealthpoints -= damageInfo.DamageAmount;

        if (damageInfo.type == DamageType.KNOCKING)
        {
            OnKnocking.Invoke(damageInfo.orientation);
        }

        m_Healthbar.SetPercentage((float) m_CurrentHealthpoints / m_TotalHealthpoints);

        if (m_CurrentHealthpoints <= 0)
        {
            m_IsDestroyed = true;
            Debug.Log($"{name} is dead!");

            
            m_Healthbar.ReturnToPool();
            m_Healthbar = null;
            
            OnDestroyed.Invoke();
        }
    }

    public void Reset()
    {
        m_CurrentHealthpoints = m_TotalHealthpoints;
        m_IsDestroyed = false;
    }
}