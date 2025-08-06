using UnityEngine;

public class ClearLevel : MonoBehaviour
{
    public void Clear()
    {
        BaseBlock[] allBlocks = FindObjectsByType<BaseBlock>(FindObjectsSortMode.None);
        if (allBlocks.Length > 0)
        {
            foreach (var item in allBlocks)
            {
                DestroyItem(item.gameObject);
            }
        }
        BallMoveScript[] allBalls = FindObjectsByType<BallMoveScript>(FindObjectsSortMode.None);
        if (allBalls.Length > 0)
        {
            foreach (var item in allBalls)
            {
                DestroyItem(item.gameObject);
            }
        }

        Bonus[] bonuses = FindObjectsByType<Bonus>(FindObjectsSortMode.None);
        if (bonuses.Length > 0)
        {
            foreach (var item in bonuses)
            {
                item.StopAndRemove();
            }
        }
        Bullet[] bullets = FindObjectsByType<Bullet>(FindObjectsSortMode.None);
        if (bullets.Length > 0)
        {
            foreach (var item in bullets)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
        private void DestroyItem(GameObject game)
    {
            #if UNITY_EDITOR
                    DestroyImmediate(game.gameObject);

            #else
                            Destroy(game.gameObject);
            #endif
    }

}
