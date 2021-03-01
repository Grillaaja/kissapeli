using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{

    private Camera cam;

    public Transform firePoint;
    public GameObject projectile;
    private float firerate;
    private float nextDmgEvent;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        firerate = GetComponentInParent<PlayerController>().attSpeed;
        Vector2 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            if(Time.time >= nextDmgEvent)
            {
                nextDmgEvent = Time.time + firerate;
                Instantiate(projectile, firePoint.position, firePoint.rotation);
            }
        }
    }
}
