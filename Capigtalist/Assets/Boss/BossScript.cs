using UnityEngine;

[RequireComponent(typeof(BossAttributes))]
public abstract class BossScript : MonoBehaviour
{
    protected BossAttributes bossAttributes;
    protected SpriteRenderer bossRenderer;

    virtual protected void Awake()
    {
        bossAttributes = GetComponent<BossAttributes>();
        bossRenderer = GetComponent<SpriteRenderer>();
    }

    public Vector2 GetCenter()
    {
        return bossRenderer.bounds.center;
    }
}
