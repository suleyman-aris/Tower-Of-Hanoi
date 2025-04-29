using UnityEngine;
using System.Collections.Generic;

public class TowerStack : MonoBehaviour
{
    public List<GameObject> stackList = new List<GameObject>();

    public void AddDisk(GameObject obj)
    {
        stackList.Add(obj);
    }

    public void RemoveLastDisk()
    {
        if (stackList.Count > 0)
        {
            int lastIndex = stackList.Count - 1;
            stackList.RemoveAt(lastIndex);
        }
    }

    public GameObject LastDisks()
    {
        if (stackList.Count == 0)
            return null;
        else
            return stackList[stackList.Count - 1];
    }

    public int GetVector3Count()
    {
        return stackList.Count;
    }
}
