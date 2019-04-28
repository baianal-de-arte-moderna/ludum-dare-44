using UnityEngine;

public class FloorRadarScript : MonoBehaviour {

    public delegate void RadarEvent();
    public event RadarEvent OnEnterRadar;

    void OnTriggerEnter2D(Collider2D other)
    {
        OnEnterRadar?.Invoke();
    }
}
