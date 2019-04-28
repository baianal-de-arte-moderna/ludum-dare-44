using UnityEngine;

public class HammerRadar : Radar
{
    public event PlayerProximityEvent OnPlayerEnterHammerRadar;
    public event PlayerProximityEvent OnPlayerStayHammerRadar;
    public event PlayerProximityEvent OnPlayerLeaveHammerRadar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeEvent(OnPlayerEnterHammerRadar, collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        InvokeEvent(OnPlayerStayHammerRadar, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InvokeEvent(OnPlayerLeaveHammerRadar, collision);
    }
}
