using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed=50f;
    public int dame = 50;
    public float explosionRadius = 0f;
    public GameObject bulletEffect;
    public void Seek(Transform targetOther)
    {
        target = targetOther;
    }
    void Update()
    {
        if (target==null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        if (dir.magnitude<  speed*Time.deltaTime)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized*Time.deltaTime*speed,Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject bulletEffectIns= Instantiate(bulletEffect, transform.position, transform.rotation) as GameObject;
        Destroy(bulletEffectIns, 2f);
        if (explosionRadius>0f)
        {
            Collider[] colliders= Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.tag=="Enermy")
                {
                    Damage(collider.transform);
                }
            }
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Damage(Transform enermy)
    {
        Enermy e = enermy.GetComponent<Enermy>();
        if (e!=null)
        {
            e.TakeDamage(dame);
        }
    }
}
