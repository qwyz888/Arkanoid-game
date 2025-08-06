using UnityEngine;
using UnityEngine.Events;
using static PlayerLife;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private UnityEventInt UIUpdate;
    [SerializeField] private UnityEvent ThousandCollected;
    private const int SCORE_TO_NEXT_BONUS = 1000;
    private int _score;

    public void SetDefault()
    {
        _score = 0;
        UIUpdate?.Invoke(_score);
    }

    public int GetScore()
    {
        return _score;
    }
    private void OnEnable()
    {
        BlockScript.OnDestroyed += ScoreCollect;
        Bonus.OnAdded += ScoreCollect;
        Ufo.OnDestroyed += ScoreCollect;
    }
    private void OnDisable()
    {
        BlockScript.OnDestroyed -= ScoreCollect;
        Bonus.OnAdded -= ScoreCollect;
        Ufo.OnDestroyed -= ScoreCollect;
    }

    private void ScoreCollect (int value)
    {
        if(_gameState.State == State.Gameplay)
        {
            _score += value;
            UIUpdate?.Invoke(_score);
            if(_score % SCORE_TO_NEXT_BONUS == 0)
            {
                ThousandCollected?.Invoke();
            }
        }
    }

}
