using UnityEngine;

public class Radar : MonoBehaviour
{
    public delegate void PlayerProximityEvent(PlayerScript playerScript);

    protected void InvokeEvent(PlayerProximityEvent playerProximityEvent, Collider2D playerCollider)
    {
        PlayerScript playerScript = playerCollider.gameObject.GetComponent<PlayerScript>();
        playerProximityEvent?.Invoke(playerScript);
    }
}
