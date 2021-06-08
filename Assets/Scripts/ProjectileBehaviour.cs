using System.Collections;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float _lifeSpan = 3f;
    void Start()
    {
        StartCoroutine(LifeSpan());
    }

    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(_lifeSpan);
        Destroy(this.gameObject);
    }
}
