using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;

public class TouchedTower : MonoBehaviour
{
    public List<GameObject> touchedObjects = new List<GameObject>();
    private Mouse mouse;
    private Touchscreen touchscreen;
    public event Action changeScore;

    void Awake()
    {
        mouse = Mouse.current;
        touchscreen = Touchscreen.current;

        if (mouse == null && touchscreen == null)
        {
            Debug.LogError("Ne fare ne de dokunmatik ekran algýlanamadý.");
            enabled = false;
        }
    }

    void Update()
    {
        if (mouse != null && mouse.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = mouse.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject touchedObject = hit.collider.gameObject;
                HandleObjectTouch(touchedObject);
            }
        }

        if (touchscreen != null && touchscreen.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 touchPosition = touchscreen.primaryTouch.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject touchedObject = hit.collider.gameObject;
                HandleObjectTouch(touchedObject);
            }
        }
    }
    void HandleObjectTouch(GameObject obj)
    {
        GameObject disk;

        if (touchedObjects.Contains(obj))   // ayný kuleye týklarsa
        {
            disk = obj.GetComponent<TowerStack>().LastDisks();
            int stackCount = obj.GetComponent<TowerStack>().GetVector3Count();
            disk.GetComponent<DiskMove>().MoveDisk(obj.transform.GetChild(stackCount).position);
            touchedObjects.Clear();
        }
        else if (touchedObjects.Count < 1 & obj.GetComponent<TowerStack>().GetVector3Count() > 0) // ilk seçilen kule
        {
            disk = obj.GetComponent<TowerStack>().LastDisks();
            if (disk == null) return;

            touchedObjects.Add(obj);
            disk.GetComponent<DiskMove>().MoveDisk(obj.transform.GetChild(0).position);
        }
        else //hedef kule
        {
            disk = touchedObjects[0].GetComponent<TowerStack>().LastDisks(); // seçilen disk
            GameObject targetDisk = obj.GetComponent<TowerStack>().LastDisks();
            if (targetDisk == null || RoleOfSize.Instance.SizeRole(disk, targetDisk))
            {
                disk.GetComponent<DiskMove>().MoveDisk(obj.transform.GetChild(0).position);
                touchedObjects[0].GetComponent<TowerStack>().RemoveLastDisk();
                obj.transform.GetChild(0).GetComponent<MoveToStack>().isMoving = true;                
                touchedObjects.Clear();
                changeScore?.Invoke();
                
            }
        }
    }
}
