using Digital.Core.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace Digital.AI
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float minDistance = 20;
        [SerializeField] private GameObject killParticles;
        public Transform shootPos;
        private Animator anim;
        private NavMeshAgent agent;

        bool hagger = false;

        private void Start()
        {
            anim = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {

            if (hagger)
            {
                float distanceFromPlayer = Vector3.Distance(transform.position, GameManager.ins.player.position);
                if (distanceFromPlayer <= minDistance)
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
            else
            {
                if (!Physics.Linecast(transform.position + Vector3.up, GameManager.ins.player.position + Vector3.up))
                {
                    hagger = true;
                }
            }
        }

        public void Kill()
        {
            Instantiate(killParticles, transform.position + Vector3.up, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
