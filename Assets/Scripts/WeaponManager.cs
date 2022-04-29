using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 100f;
    public float damage = 25f;
    public Animator playerAnimator;
    AudioSource m_shootingSound;
    // Start is called before the first frame update
    void Start()
    {
        m_shootingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting",false);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Shoot");
            Shoot();
            m_shootingSound.Play();
        }
        
    }

    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);

        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
           // Debug.Log("hit");

           EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
           if (enemyManager != null)
           {
               enemyManager.Hit(damage);
           }

        }
    }
}
