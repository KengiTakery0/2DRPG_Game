using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum State
    {
        Remainin,
        Atack,
    }
    private State state;
    private EnemyPathFinding pathFinding;

    private void Awake()
    {
        state = State.Remainin;
        pathFinding = GetComponent<EnemyPathFinding>();
    }
    private void Start()
    {
        StartCoroutine(P());
    }

    private IEnumerator P()
    {
        while (state == State.Remainin)
        {
            
           //pathFinding.GetMoveDir();
            yield return new WaitForSeconds(2f);
        }
    }

   

}
