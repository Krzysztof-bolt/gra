using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint; // Miejsce, z którego wylatuje pocisk
    public GameObject bulletPrefab; // Prefabrykat pocisku

    public float bulletForce = 20f; // Si³a pocisku

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Przypisanie strza³u do lewego przycisku myszy (mo¿esz zmieniæ na swój wybór)
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
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse); // Nadawanie si³y pociskowi
        }
        // Dodaj tutaj inne efekty, takie jak dŸwiêk strza³u, animacje, efekty wizualne itp.
    }
}