using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint; // Miejsce, z kt�rego wylatuje pocisk
    public GameObject bulletPrefab; // Prefabrykat pocisku

    public float bulletForce = 20f; // Si�a pocisku

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Przypisanie strza�u do lewego przycisku myszy (mo�esz zmieni� na sw�j wyb�r)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Tworzenie pocisku

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse); // Nadawanie si�y pociskowi
        }
        // Dodaj tutaj inne efekty, takie jak d�wi�k strza�u, animacje, efekty wizualne itp.
    }
}