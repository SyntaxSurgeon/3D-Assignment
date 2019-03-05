using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleParticlesV2 : MonoBehaviour
{
    public ParticleSystem muzzleParticles;
    public ParticleSystem bulletParticles;

    private void Start()
    {
        muzzleParticles.Stop();
        bulletParticles.Stop();
    }

    private void EnableWeaponParticles()
    {
        muzzleParticles.Play();
    }

    private void EnableBulletParticles()
    {
        bulletParticles.Play();
    }

    private void DisableWeaponParticles()
    {
        muzzleParticles.Stop();
    }

    private void DisableBulletParticles()
    {
        bulletParticles.Stop();
    }
}
