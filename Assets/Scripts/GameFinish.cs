using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    public static GameFinish Instance;

    public TMP_Text isFinish;

    public List<GameObject> correctList = new List<GameObject>();
    public List<GameObject> towerList = new List<GameObject>();
    
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }


    public void CheckGameFinish()
    {
        for (int i = 0; i < towerList.Count; i++)
        {
            if (towerList[i].GetComponent<TowerStack>().stackList.Count == correctList.Count)
            {
                for (int j = 0; j < towerList[i].GetComponent<TowerStack>().stackList.Count; j++)
                {
                    if (towerList[i].GetComponent<TowerStack>().stackList[j] != correctList[j])
                        return;
                }
                isFinish.gameObject.SetActive(true);
            }
        }
    }
}
