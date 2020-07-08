using Digital.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Digital.AI
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float minDistance = 10;
        [SerializeField] GameObject killParticles;
        public Transform shootPos;

        Animator anim;
        NavMeshAgent agent;

        private void Start()
        {
            anim = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(Vector3.Distance(transform.position, GameManager.ins.player.position) <= minDistance)
            {
                anim.SetTrigger("Shoot");
                agent.isStopped = true;
                transform.LookAt(GameManager.ins.player);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
            else
            {
                agent.isStopped = false;
                agent.SetDestination(GameManager.ins.player.position);
            }
        }

        public void Kill()
        {
            Instantiate(killParticles, transform.position + Vector3.up, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
