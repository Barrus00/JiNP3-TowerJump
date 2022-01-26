using UnityEngine;
using UnityEngine.Events;

public class WinFlagScript : MonoBehaviour
{
    public UnityEvent<string> OnWin = new UnityEvent<string>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnWin.Invoke(collision.gameObject.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION!");
        OnWin.Invoke(collision.gameObject.name);
    }
}
