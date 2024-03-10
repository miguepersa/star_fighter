using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private ProjectileController prefab;
    [SerializeField] private Transform mountPoint = null;
    [SerializeField] private Transform parent = null;

    private int numOfSubs = 0;

    public void Suscribe(PlayerController player)
    {
        numOfSubs++;
        player.OnShot += Shoot;
    }

    public void Unsuscribe(PlayerController player)
    {
        numOfSubs--;
        player.OnShot -= Shoot;
    }

    public void Shoot()
    {
        if (numOfSubs <= 0) return;

        var projectile = Instantiate(prefab, mountPoint.position, Quaternion.identity, parent);
        projectile.transform.up = mountPoint.up;
    }

}
