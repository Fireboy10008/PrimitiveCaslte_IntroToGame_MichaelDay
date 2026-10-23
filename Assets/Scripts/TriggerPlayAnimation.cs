using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayAnimation : MonoBehaviour
{
    public GameObject AnimatedObject;

    private Animator _animator;

    private void Start()
    {
        _animator = AnimatedObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        _animator.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        _animator.enabled = false;
    }


}
