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
    //Dictates whether the agent waits on each node.
    public bool _WaitingOnDestinationPlace;

    //The total time we wait at each node.
    [SerializeField]
    float _totalWaitTime = 3f;

    bool _travelling;
    bool _waiting;
    float _waitTimer;
    GameObject selected_object;

    // Use this for initialization
    public void Start()
    {
        _navMeshagent = this.GetComponent<NavMeshAgent>();

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
        //Check if we're close to the destination.
        if (_travelling && _navMeshagent.remainingDistance <= distancefromTarget)
        {
            _travelling = false;
            //If we're going to wait, then wait.
            if (_WaitingOnDestinationPlace)
            {
                _waiting = true;
                _waitTimer = 0f;
                //switch (EatObject.getObjectKind())
                //{
                //    case "crumble":
                //        ScoreScript.CrumblesCounterBot++;
                //        Debug.Log("crumbles bot= " + ScoreScript.CrumblesCounterBot);
                //        break;
                //    case "stone":
                //        ScoreScript.StoneCounterBot++;
                //        Debug.Log("stones bot= " + ScoreScript.StoneCounterBot);
                //        break;
                //    default:
                //        break;
                //}
                _navMeshagent.Stop();
                if (_navMeshagent.isStopped) {
                    Destroy(selected_object);
                }
                _navMeshagent.Resume();
            }
            else
            {
                SetDestination();
                Destroy(selected_object);
            }
        }
        //Instead if we're waiting.
        if (_waiting)
        {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= _totalWaitTime)
            {   
                _waiting = false;
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        selected_object = FindClosestTarget(Tag);
        Vector3 targetVector = selected_object.transform.position;
        _navMeshagent.SetDestination(targetVector);
        _travelling = true;
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