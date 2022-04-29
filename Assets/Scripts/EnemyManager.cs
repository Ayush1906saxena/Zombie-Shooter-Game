using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20f;
    public float health = 100f;
    public GameManager gameManager;
    AudioSource m_zombieWalkingSound;
    public void Hit(float damage)
    {
        health -= damage;
        if(health <=0 )
        {
            gameManager.enemiesAlive--;
            //Destroy Enemy(ZOMBIE)
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(true);
        m_zombieWalkingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1){
            enemyAnimator.SetBool("isWalking", true);
            m_zombieWalkingSound.Play();
        }
        else{
            enemyAnimator.SetBool("isWalking", false);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject == player)
        {

            Debug.Log("We got hit by a zombie");
            player.GetComponent<PlayerManager>().Hit(damage);
            
        }
    }
}
