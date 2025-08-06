using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<poolData> _inactiveList = new List<poolData>();
    [SerializeField] private List<poolData> _activeList = new List<poolData>();

    [SerializeField] private List<poolData> _ballPrefabs;

    public GameObject GetGameObjectFromPool(BallType ballType)
    {
        //go through the inactive list to find an object of the requested type
        foreach (var item in _inactiveList)
        {
            if (item.ballType == ballType)
            {
                _inactiveList.Remove(item);
                _activeList.Add(item);
                item.ball.SetActive(true);
                return item.ball;
            }
        }

        //if no object found instantiate a new one
        foreach(var item in _ballPrefabs)
        {
            if (item.ballType == ballType)
            {
                GameObject newBall = Instantiate(item.ball, new Vector3(0, 0, 0), Quaternion.identity);
                poolData newPoolData = new poolData
                {
                    ball = newBall,
                    ballType = ballType
                };
                _activeList.Add(newPoolData);
                return newBall;
            }
        }
        return null;
    }

    public void ReturnGameObjectToPool(GameObject ball)
    {
        //find the object in the active list and move it to the inactive list
        for (int i = 0; i < _activeList.Count; i++)
        {
            if (_activeList[i].ball == ball)
            {
                _activeList[i].ball.SetActive(false);
                _inactiveList.Add(_activeList[i]);
                _activeList.RemoveAt(i);
                return;
            }
        }
        Debug.LogWarning("Object not found in active list");
    }
}
[System.Serializable]
public struct poolData
{
    public GameObject ball;
    public BallType ballType;
}
public enum BallType
{
    Normal
}