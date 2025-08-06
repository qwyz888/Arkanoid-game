using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private const float OffsetY = 0.2f;
    private readonly List<GameObject> _listOfBalls = new();
    

    public void Create()
    {
        _listOfBalls.Clear();
        _listOfBalls.Add(Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y + OffsetY), Quaternion.identity,transform));
        
    }

    public void CreateClone()
    {
        foreach(var item in _listOfBalls)
        {
            if (item!= null)
            {
                GameObject cloneOne = Instantiate(ballPrefab, new Vector3(item.transform.position.x, item.transform.position.y ), 
                    Quaternion.identity,null);
                GameObject cloneTwo = Instantiate(ballPrefab, new Vector3(item.transform.position.x, item.transform.position.y),
                    Quaternion.identity, null);
                cloneOne.GetComponent<BallMoveScript>().StartClone(1f);
                cloneTwo.GetComponent<BallMoveScript>().StartClone(-1f);
                _listOfBalls.Add(cloneOne);
                _listOfBalls.Add(cloneTwo);
                break;

            }
        }
    }
}
