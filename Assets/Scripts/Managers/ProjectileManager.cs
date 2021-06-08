using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private float      _projectileSpeed = 1f;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform  _spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject newProjectile = Instantiate(_projectilePrefab, _spawnPoint.position, Quaternion.identity, transform);
                newProjectile.transform.LookAt(hit.point);
                newProjectile.GetComponent<Rigidbody>().AddForce(newProjectile.transform.forward * 100000 * _projectileSpeed * Time.deltaTime);
            }
        }
    }
}
