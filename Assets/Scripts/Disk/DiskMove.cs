using UnityEngine;
using DG.Tweening;

public class DiskMove : MonoBehaviour
{
    public TouchedTower touchedTower;
    public float movementSpeed;

    

    public void MoveDisk(Vector3 targetPosition)
    {
        float maxDistanceThisFrame = movementSpeed * Time.deltaTime;
        transform.DOMove(targetPosition, movementSpeed);
    }
}
