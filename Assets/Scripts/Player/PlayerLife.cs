using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : MonoBehaviour
{
    private const int MAX_LIFE = 3;
    private int _life;

    [SerializeField] private GameState _gameState;
    [SerializeField] private UnityEvent OnAllLifeLosted;
    [SerializeField] private UnityEvent OnLifeLosted;
    [SerializeField] private UnityEventInt UIUpdate;

    public int GetLifesCount()
    {
        return _life;
    }
    public void SetDefault()
    {
        _life = MAX_LIFE;
        UIUpdate.Invoke(_life);
    }

    private void OnEnable()
    {
        BallCount.OnEnded += LostLife;
    }
    private void OnDisable()
    {
        BallCount.OnEnded -= LostLife;
    }

    private void LostLife()
    {
       
        if (_gameState.State == State.Gameplay)
        {
            _life--;
            
            if (_life < 1)
            {
                OnAllLifeLosted.Invoke();

            }
            else
            {
                
                OnLifeLosted.Invoke();
               
            }
            UIUpdate.Invoke(_life);
        }
    }

    [System.Serializable]
    public class UnityEventInt : UnityEvent<int> { }
    

}
