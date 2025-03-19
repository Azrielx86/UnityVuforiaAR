using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Vuforia;

public class Move : MonoBehaviour
{
    public GameObject model;
    public ObserverBehaviour[] imageTargets;
    public int currentTarget;
    public float speed = 1.0f;
    private bool _isMoving = false;

    public void MoveToTarget(ObserverBehaviour target)
    {
        if (!_isMoving)
            StartCoroutine(MoveModelToTarget(target));
    }

    private IEnumerator MoveModelToTarget(ObserverBehaviour target)
    {
        _isMoving = true;

        if (target is null)
        {
            _isMoving = false;
            yield break;
        }

        var startPosition = model.transform.position;
        var endPosition = target.transform.position;

        float journey = 0;

        while (journey <= 1f)
        {
            journey += Time.deltaTime * speed;
            model.transform.position = Vector3.Lerp(startPosition, endPosition, journey);
            yield return null;
        }

        currentTarget = (currentTarget + 1) % imageTargets.Length;
        _isMoving = false;
    }

    #region EjemploClase

    public void MoveToNextMarker()
    {
        if (!_isMoving)
            StartCoroutine(MoveModel());
    }

    private IEnumerator MoveModel()
    {
        _isMoving = true;
        var target = GetNextDetectedTarget();

        if (target is null)
        {
            _isMoving = false;
            yield break;
        }

        var startPosition = model.transform.position;
        var endPosition = target.transform.position;

        float journey = 0;

        while (journey <= 1f)
        {
            journey += Time.deltaTime * speed;
            model.transform.position = Vector3.Lerp(startPosition, endPosition, journey);
            yield return null;
        }

        currentTarget = (currentTarget + 1) % imageTargets.Length;
        _isMoving = false;
    }

    [CanBeNull]
    private ObserverBehaviour GetNextDetectedTarget()
    {
        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var target in imageTargets)
            if (target is not null && target.TargetStatus.Status is Status.TRACKED or Status.EXTENDED_TRACKED)
                return target;
        return null;
    }

    #endregion
}