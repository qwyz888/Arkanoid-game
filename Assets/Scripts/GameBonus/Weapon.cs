using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Weapon : Bonus
{
    private ObjectPool _bulletsPool;
    private const float OFFSET_Y = 0.1f;
    private const float OFFSET_X = 0.1f;
    
    public override void Apply()
    {
        StartTimer();
        StartCoroutine(StartShoot());
    }

    private void OnEnable()
    {
        if (_bulletsPool == null)
        {
            ObjectPool[] objectPools = FindObjectsByType<ObjectPool>(FindObjectsSortMode.None);
            for (int i = 0; i < objectPools.Length; i++)
            {
                if (objectPools[i].gameObject.CompareTag("BulletPool"))
                {
                    _bulletsPool = objectPools[i];
                    break;
                }

                
            }
        }
    }



    private IEnumerator StartShoot()
    {
        while (true)
        {
            ActivateBullet(OFFSET_X);
            Debug.LogWarning("Left Bullet was generated" + OFFSET_X);
            ActivateBullet(-OFFSET_X);
            Debug.LogWarning("Right Bullet was generated"+ -OFFSET_X);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void ActivateBullet(float offsetX)
    {
        GameObject bullet = _bulletsPool.GetObject();
        if(bullet != null)
        {
            bullet.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y + OFFSET_Y);
            bullet.SetActive(true);
        }
    }
}
