using Digital.Core.Managers;
using Digital.Weapons;
using UnityEngine;

namespace Digital.AI
{
    public class EnemyShoot : StateMachineBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        private Transform shootPos;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            shootPos = animator.GetComponent<Enemy>().shootPos;
            GameObject ins = Instantiate(bulletPrefab, shootPos.position, shootPos.rotation);
            ins.GetComponent<Bullet>().direction = (GameManager.ins.player.position - shootPos.position).normalized;
            ins.GetComponent<Bullet>().type = Bullet.Type.ENEMY;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}

