using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public enum CurrentState { idle, trace, attack, dead };
    public CurrentState curState = CurrentState.idle;

    private Transform _transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;

    private Animator _animator;


    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();

        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        _animator = this.gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckStateForAction());
    }

    IEnumerator CheckStateForAction()
    {
        while(!isDead)
        {
            switch(curState)
            {
                case CurrentState.idle:
                    nvAgent.isStopped = true;
                    _animator.SetBool("isTrace", false);
                    break;
                case CurrentState.trace:
                    nvAgent.destination = playerTransform.position;
                    nvAgent.isStopped = false;
                    _animator.SetBool("isTrace", true);
                    break;
            }

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
