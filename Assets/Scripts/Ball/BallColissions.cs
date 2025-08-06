using UnityEngine;

public class BallColissions : MonoBehaviour
{
    [SerializeField] private BallMoveScript _ball;
    [SerializeField] private BallSound _ballSound;
    private float _lastPositionX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ballSound.PlaySoundCollision();
        float ballPositionX = transform.position.x;

        // Перевірка на зіткнення з платформою
        if (collision.gameObject.TryGetComponent(out PlayerMove player))
        {
            if (ballPositionX < _lastPositionX + 0.2 && ballPositionX > _lastPositionX - 0.2)
            {
                float collisionPointX = collision.contacts[0].point.x;
                float playerCenterPosition = player.gameObject.GetComponent<Transform>().position.x;
                float difference = playerCenterPosition - collisionPointX;
                float direction = collisionPointX < playerCenterPosition ? -10 : 10;
                _ball.AddForce(direction * Mathf.Abs(difference));
            }
            _ball.ResetNoBlockHitTimer(); // Скидаємо таймер після удару
        }
        _lastPositionX = ballPositionX;

        // Перевірка на зіткнення з блоком
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage();
            _ball.ResetNoBlockHitTimer(); // Скидаємо таймер після удару
        }

       if (collision.gameObject.TryGetComponent( out BlockComposite blockComposite))
        {
            blockComposite.ApplyDamage(collision.contacts[0].point);

        }
    }
}
