using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float Speed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage();
        }
        gameObject.SetActive(false);
    }
}
