using System;
using UnityEngine;

public class Ufo : MonoBehaviour, IDamageable
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private ParticleSystem _particleSystem;
    private const int SCORE = 500;
    private const float SPEED = 1f;
    private float _maxDistance;

    public static event Action<int> OnDestroyed;

    private void OnEnable()
    {
        ShowObject(true);
        _maxDistance = Math.Abs(transform.position.x);
    }
   
    private void Update()
    {
        transform.Translate(Vector3.right * SPEED * Time.deltaTime);
        if(transform.position.x > _maxDistance)
        {
            gameObject.SetActive(false);
        }
    }

    private void ShowObject(bool value)
    {
        GetComponent<SpriteRenderer>().enabled = value;
        GetComponent<BoxCollider2D>().enabled = value;
        
    }
    public void ApplyDamage()
    {
        ShowObject(false);
        GetComponent<ParticleSystem>().Play();
        OnDestroyed?.Invoke(SCORE);
    }
}
