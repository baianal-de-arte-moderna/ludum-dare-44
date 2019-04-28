using UnityEngine;

public abstract class Radar : MonoBehaviour
{
    public delegate void PlayerProximityEvent(PlayerScript playerScript);
    public event PlayerProximityEvent OnPlayerEnterRadar;
    public event PlayerProximityEvent OnPlayerStayRadar;
    public event PlayerProximityEvent OnPlayerLeaveRadar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeEvent(OnPlayerEnterRadar, collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        InvokeEvent(OnPlayerStayRadar, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InvokeEvent(OnPlayerLeaveRadar, collision);
    }

    protected void InvokeEvent(PlayerProximityEvent playerProximityEvent, Collider2D playerCollider)
    {
        PlayerScript playerScript = playerCollider.gameObject.GetComponent<PlayerScript>();
        playerProximityEvent?.Invoke(playerScript);
    }
}
