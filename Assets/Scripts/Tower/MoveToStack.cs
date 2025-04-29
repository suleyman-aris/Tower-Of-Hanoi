using UnityEngine;

public class MoveToStack : MonoBehaviour
{
    public bool isMoving = false;
    private void OnTriggerEnter(Collider other)
    {
        GameObject tower = transform.parent.gameObject;
        if (isMoving)
        {            
            int stackCount = tower.GetComponent<TowerStack>().GetVector3Count();
            other.gameObject.GetComponent<DiskMove>().MoveDisk(tower.transform.GetChild(stackCount + 1).position);
            tower.GetComponent<TowerStack>().AddDisk(other.gameObject);
            isMoving = false;
            GameFinish.Instance.CheckGameFinish();
        }
        
    }
}
