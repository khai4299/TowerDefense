using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("General")]
    public float range = 15f;
    [Header("Defaul")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    [Header("Laser")]
    public bool useLaser = false;
    public int dPS = 30;
    public float slowAmount = 0.5f;
    public LineRenderer lineRenderer;
    public ParticleSystem laserEffect;
    public Light light;
    [Header("Tranform")]
    public Transform partToRotate;
    public Transform fireBorn;
    private Transform target;
    private Enermy targetEnermy;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {

        if (GameManager.endGame)
            return;
        GameObject[] enermies = GameObject.FindGameObjectsWithTag("Enermy");
        float shortestDir = Mathf.Infinity;
        GameObject nearestEnermy = null;
        foreach (var enermy in enermies)
        {
            float dis = Vector3.Distance(transform.position, enermy.transform.position);
            if (dis<shortestDir)
            {
                nearestEnermy = enermy;
                shortestDir = dis;
            }    
        }
        if (nearestEnermy !=null && shortestDir <= range)
        {
            target = nearestEnermy.transform;
            targetEnermy = nearestEnermy.GetComponent<Enermy>();
        }
        else
        {
            target = null;
        }
    }
    void Update()
    {

        if (GameManager.endGame)
            return;
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserEffect.Stop();
                    light.enabled = false;
                }                 
            }
            return; 
        }
        LookAtTarget();
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }
    void Laser()
    {
        targetEnermy.TakeDamage(dPS*Time.deltaTime);
        targetEnermy.Slow(slowAmount);
        if (!lineRenderer.enabled)
        {
            laserEffect.Play();
            light.enabled = true;
            lineRenderer.enabled = true;
        }
        lineRenderer.SetPosition(0, fireBorn.position);
        lineRenderer.SetPosition(1, target.position);
        Vector3 dir = fireBorn.position - target.position;
        laserEffect.transform.position = target.position+dir.normalized*.3f;
        laserEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
    void LookAtTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Shoot()
    {
        GameObject bulletIns= Instantiate(bulletPrefab, fireBorn.position, fireBorn.rotation);
        Bullet bullet=bulletIns.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
