using UnityEngine;

public class UfoGenerator : MonoBehaviour
{
    private const float MIN_POSITION_Y = -0.3f;
    private const float MAX_POSITION_Y = 1.4f;
    private ObjectPool _ufosPool;

    private void OnEnable()
    {
        if(_ufosPool == null)
        {
            ObjectPool[] objectPools = FindObjectsByType< ObjectPool>(FindObjectsSortMode.None);
            for (int i = 0; i < objectPools.Length; i++)
            {
                if (objectPools[i].CompareTag("UfoPool"))
                {
                    _ufosPool = objectPools[i];
                    break;
                }
            }
           
        }
    }

    public void Generate()
    {
        GameObject ufo = _ufosPool.GetObject();
        if(ufo != null)
        {
            float tempY = Random.Range(MIN_POSITION_Y, MAX_POSITION_Y);
            ufo.transform.position = new Vector2(transform.position.x, tempY);
            ufo.SetActive(true);

       }

    }
}
