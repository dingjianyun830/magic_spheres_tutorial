using System.Collections;
using UnityEngine;

public class ExplodeAfterDetach : MonoBehaviour
{
    [SerializeField] private GameObject _explodeGameObject;
    [SerializeField] private GameObject _disableOnExplode;
    [SerializeField] private float _explodeTime = 2.5f;
    [SerializeField] private float _destoryTime = 1.5f;

    private Coroutine _explodeRoutine;

    public void Detach()
    {
        if (_explodeRoutine != null)
        {
            return;
        }

        _explodeRoutine = StartCoroutine(ExplodeRoutine());
    }

    IEnumerator ExplodeRoutine()
    {
        var timeCounter = 0.0f;
        while (timeCounter < _explodeTime)
        {
            timeCounter += Time.deltaTime;
            yield return null;
        }

        Explode();
    }

    private void Explode()
    {
        if (_explodeGameObject != null)
        {
            _explodeGameObject.SetActive(true);
        }

        if (_disableOnExplode != null)
        {
            _disableOnExplode.SetActive(false);
        }
        
        StartCoroutine(DestroyRoutine());
    }

    IEnumerator DestroyRoutine()
    {
        var timeCounter = 0.0f;
        while (timeCounter < _destoryTime)
        {
            timeCounter += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
