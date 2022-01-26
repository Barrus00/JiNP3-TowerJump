using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rising_lava : MonoBehaviour
{
    [SerializeField]
    private float m_lavaRisingSpeed = 2;

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 1) * m_lavaRisingSpeed * Time.deltaTime;
    }
}
