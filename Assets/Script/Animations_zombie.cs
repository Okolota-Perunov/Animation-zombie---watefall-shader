using UnityEngine;

public class Animations_zombie : MonoBehaviour
{
    private Rigidbody[] _childrenRigidbody;
    private int _childrenRigidbodyLength;
    private Animator _zombieAnimator;

    private void Start()
    {
        _zombieAnimator = GetComponent<Animator>();
        _childrenRigidbody = GetComponentsInChildren<Rigidbody>();

        _childrenRigidbodyLength = _childrenRigidbody.Length;

        for(int i = 0; i < _childrenRigidbodyLength; i++)
        {
            _childrenRigidbody[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            _zombieAnimator.SetFloat("Speed", 1);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            _zombieAnimator.SetFloat("Speed", 0);
        }

        if(Input.GetMouseButtonDown(0))
        {
            _zombieAnimator.SetInteger("Types_of_attack",Random.Range(1,3));
        }
        if(Input.GetMouseButtonUp(0))
        {
            _zombieAnimator.SetInteger("Types_of_attack",0);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Animator>().enabled = false;
            for(int i = 0; i < _childrenRigidbodyLength; i++)
            {
                _childrenRigidbody[i].GetComponent<Rigidbody>().isKinematic = false;
            }   
        }
    }
}
