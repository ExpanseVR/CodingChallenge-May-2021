using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
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
                GameObject newProjectile = Instantiate(_projectilePrefab, _spawnPoint.position, Quaternion.identity);
                newProjectile.transform.LookAt(hit.point);
                newProjectile.GetComponent<Rigidbody>().velocity = newProjectile.transform.forward * 15000 * Time.deltaTime;
            }
        }
    }
}
