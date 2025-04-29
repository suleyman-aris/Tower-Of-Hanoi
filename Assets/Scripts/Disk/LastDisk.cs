using UnityEngine;

public class LastDisk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void FindLastDisk()
    {
        gameObject.GetComponent<TowerStack>().RemoveLastDisk();
    }
}
