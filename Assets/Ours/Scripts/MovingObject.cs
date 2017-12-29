using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class MovingObject : MonoBehaviour
{
    public float distancefromTarget;
    public string Tag;
    NavMeshAgent _navMeshagent;
    static Animator _anim;
    float _totalWaitTime = 5.15f;
    float _eatTime = 1.28f;
    bool _travelling;
    bool _waiting;
    bool _eatObject;
    float _waitTimer;
    GameObject selected_object;
    //public static bool consumedObject = false;

    public void Start()
    {
        _navMeshagent = this.GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        if (_navMeshagent == null)
        {
            Debug.LogError("Nav Mesh Agent component not found attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    public void Update()
    {   
        if (_travelling && _navMeshagent.remainingDistance <= distancefromTarget)
        {
            _travelling = false;
            _navMeshagent.isStopped = true;
            _anim.SetBool("isEating", true);
            _anim.SetBool("isWalking", false); 
            _waitTimer = 0f;
            _waiting = true;
            _eatObject = true;
        }
        //Instead if we're waiting.
        if (_waiting)
        {
            _waitTimer += Time.deltaTime;
            if (_eatObject && _waitTimer >= 1.26f) {
                if (selected_object != null)
                {
                    //consumedObject = true;
                    Destroy(selected_object);
                    EatObject.counterIncrement(EatObject.pickableObject, "Bot");
                    //consumedObject = true;
                }               
                _eatObject = false;
                //consumedObject = false;
            }
            if (_waitTimer >= _totalWaitTime)
            {
                _navMeshagent.isStopped = false;
                _waiting = false;       
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if (GameObject.FindWithTag("Pickable"))
        {
            selected_object = FindClosestTarget(Tag);
            Vector3 targetVector = selected_object.transform.position;
            _anim.SetBool("isWalking", true);
            _anim.SetBool("isEating", false);
            _navMeshagent.isStopped = false;
            _navMeshagent.SetDestination(targetVector);
            _travelling = true;
        }
        
    }

    private GameObject FindClosestTarget(string trgt)
    {
        Vector3 pigeon_position = transform.position;
        GameObject selected_object;
        selected_object = GameObject.FindGameObjectsWithTag(trgt)
            .OrderBy(o => (o.transform.position - pigeon_position).sqrMagnitude)
            .FirstOrDefault();
        return selected_object;
    }
}