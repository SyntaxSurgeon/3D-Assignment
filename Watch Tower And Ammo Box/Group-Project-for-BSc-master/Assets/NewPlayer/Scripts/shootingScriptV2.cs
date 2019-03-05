using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shootingScriptV2 : MonoBehaviour
{ 
    Animator weaponAnimator;

    private bool isReloading = false;

    private int ammoPack = 30;

    public int bulletUIcount = 30;
    public GameObject ammoUI;
    public TextMeshProUGUI ammoText;

    [SerializeField] int damageDealt = 20;
    public LayerMask layermask;

    public static int allRifleAmmo = 90;
    [SerializeField] private int fullRifleAmmo = 30;
    [SerializeField] public int currentRifleAmmo;
    [SerializeField] private int reloadAmount;

    void Start()
    {
        weaponAnimator = GetComponentInChildren<Animator>();

        currentRifleAmmo = fullRifleAmmo;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        layermask = Physics.IgnoreRaycastLayer;
        layermask = ~layermask;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && currentRifleAmmo > 0 && isReloading == false)
        {
            weaponAnimator.SetBool("Shooting", true);

            
        }
        else
        {
            weaponAnimator.SetBool("Shooting", false);
        }

        if (Input.GetKeyUp("r") && currentRifleAmmo < fullRifleAmmo && allRifleAmmo > 0 && isReloading == false)
        {
            weaponAnimator.SetBool("IsReloading", true);

            isReloading = true;
        }

        ammoText.text = currentRifleAmmo + " / " + allRifleAmmo;
    }

    void ShootRifle()
    {
        currentRifleAmmo -= 1;

        bulletUIcount -= 1;

        ammoUI.transform.GetChild(bulletUIcount).gameObject.SetActive(false);

        print("Fire");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Ray mouseRay = GetComponentInParent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        //anim.SetTrigger("Fire");

        if (Physics.Raycast(mouseRay, out hitInfo, 100, layermask))
        {
            print("hit" + hitInfo.transform.gameObject);
            Debug.DrawLine(transform.position, hitInfo.point, Color.red, 5.0f);
            Health enemyHealth = hitInfo.transform.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(damageDealt);

            }
        }

    }

    void Reload()
    {
        reloadAmount = fullRifleAmmo - currentRifleAmmo;


        if (reloadAmount <= allRifleAmmo)
        {
            allRifleAmmo -= reloadAmount;

            currentRifleAmmo += reloadAmount;

            for (int i = currentRifleAmmo; i > bulletUIcount; ++bulletUIcount)
            {
                ammoUI.transform.GetChild(bulletUIcount).gameObject.SetActive(true);
            }
        }
        else if (reloadAmount > allRifleAmmo)
        {
            currentRifleAmmo += allRifleAmmo;

            allRifleAmmo -= allRifleAmmo;

            for (int i = currentRifleAmmo; i > bulletUIcount; ++bulletUIcount)
            {
                ammoUI.transform.GetChild(bulletUIcount).gameObject.SetActive(true);
            }
        }

        weaponAnimator.SetBool("IsReloading", false);

        isReloading = false;
    }

    public void AddAmmo()
    {
        allRifleAmmo += ammoPack;

        if (allRifleAmmo > 90)
        {
            allRifleAmmo = 90;
        }
    }
}