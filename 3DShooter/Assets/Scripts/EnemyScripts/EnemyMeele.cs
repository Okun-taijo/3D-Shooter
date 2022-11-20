using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeele : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemyAgent;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private float _distance;
    [SerializeField] private float _actionDistance;
    [SerializeField] private float _attackDistance;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _punchTrigger;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(_target.position, transform.position);
        if (_distance > _actionDistance)
        {
            Idle();
        }
        if (_distance < _actionDistance && _distance>_attackDistance)
        {
            Catching();
        }
        if (_distance <= _attackDistance)
        {
            Attack();
        }
    }

    private void Idle()
    {
        _enemyAgent.enabled = false;
        _punchTrigger.SetActive(false);
        _enemyAnimator.SetTrigger("Idle");
    }

    private void Catching()
    {
        _enemyAgent.enabled = true;
        _punchTrigger.SetActive(false);
        _enemyAgent.SetDestination(_target.position);
        _enemyAnimator.SetTrigger("Catch");
    }

    private void Attack()
    {
        _enemyAgent.enabled = false;
        _punchTrigger.SetActive(true);
        _enemyAnimator.SetTrigger("Attack");
    }
}
