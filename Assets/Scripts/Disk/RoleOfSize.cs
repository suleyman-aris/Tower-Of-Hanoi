using UnityEngine;

public class RoleOfSize : MonoBehaviour
{
    public static RoleOfSize Instance;
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }

    public bool SizeRole(GameObject moveDisk, GameObject targetDisk)
    {
        if (targetDisk != null & moveDisk.transform.localScale.x > targetDisk.transform.localScale.x)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
