using UnityEngine;

public class PlayerRadarScript : MonoBehaviour {

    public delegate void RadarEvent(Collider2D other);
    public event RadarEvent OnEnterRadar;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) OnEnterRadar?.Invoke(other);
    }
}
