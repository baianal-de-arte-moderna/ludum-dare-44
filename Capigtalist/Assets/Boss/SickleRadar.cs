using UnityEngine;

public class SickleRadar : Radar
{
    public event PlayerProximityEvent OnPlayerEnterSickleRadar;
    public event PlayerProximityEvent OnPlayerStaySickleRadar;
    public event PlayerProximityEvent OnPlayerLeaveSickleRadar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeEvent(OnPlayerEnterSickleRadar, collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        InvokeEvent(OnPlayerStaySickleRadar, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InvokeEvent(OnPlayerLeaveSickleRadar, collision);
    }
}
