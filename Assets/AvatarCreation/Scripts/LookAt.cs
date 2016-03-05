using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LookAt : MonoBehaviour 
{
    public Transform target;
    public bool ignoreY;

	void Update () 
	{
        if (!target)
            return;

        Vector3 targetPos = target.position;

        if (ignoreY)
            targetPos.y = transform.position.y;

        transform.LookAt(targetPos);
	}
}
