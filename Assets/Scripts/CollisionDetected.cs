using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    Animator _animator;
    CapsuleCollider _capsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "RightSword")
        {
            _capsuleCollider.enabled = false;
            _animator.SetBool("isDeath", true);
        }
    }
}
