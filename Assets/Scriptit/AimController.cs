using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{

    private Camera cam;

    public Transform firePoint;
    public GameObject projectile;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetMouseButtonDown(0)){
            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }
    }
}
