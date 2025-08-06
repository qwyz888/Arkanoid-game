using UnityEngine;

public class GlassField : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _boxCollider2D;

    public void SetActive(bool value)
    {
        _boxCollider2D.enabled = value;
        _spriteRenderer.enabled = value;
    }

}
