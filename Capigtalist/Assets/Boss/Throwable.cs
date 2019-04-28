using UnityEngine;

public class Throwable : MonoBehaviour
{
    public new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
}
