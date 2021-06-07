using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SingularHealth.Cube.CubeDisplay;

namespace SingularHealth.Managers
{
    public class SpawnMananger : MonoBehaviour
    {
        private static SpawnMananger _instance;
        public static SpawnMananger Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("The SpawnManager is NULL");

                return _instance;
            }
        }

        public static event Action<GameObject, CubeState, Vector3> OnSpawnedCube;

        [SerializeField] private GameObject _cubePrefab;
        [SerializeField] private float _distance = 1.1f;
        [SerializeField] private float _spawnDelay = 0.08f;

        private List<GameObject> _spawnedCubes = new List<GameObject>();
        private List<Vector3> _positionsTaken = new List<Vector3>();

        private void Awake()
        {
            _instance = this;
        }

        public IEnumerator GenerateCubes(int size, int remainder)
        {
            ClearCubes();

            for (int yPos  = 0; yPos <= size; yPos++)
            {
                for (int zPos = 0; zPos <= size; zPos++)
                {
                    for (int xPos = 0; xPos <= size; xPos++)
                    {
                        Vector3 currentVector = new Vector3(xPos * _distance, yPos * _distance, zPos * _distance);
                        _positionsTaken.Add(currentVector);

                        CreateCube(currentVector, CubeState.Used);

                        yield return new WaitForSeconds(_spawnDelay);
                    }
                }
            }
            StartCoroutine(SpawnRemainderCubes(remainder, size+1));
        }

        IEnumerator SpawnRemainderCubes(int remainder, int size)
        {
            int count = 0;
            for (int yPos = 0; yPos <= size; yPos++)
            {
                for (int zPos = 0; zPos <= size; zPos++)
                {
                    for (int xPos = 0; xPos <= size; xPos++)
                    {
                        Vector3 currentVector = new Vector3(xPos * _distance, yPos * _distance, zPos * _distance);
                        if (_positionsTaken.Contains(currentVector))
                            continue;

                        if (count < remainder)
                            CreateCube(currentVector, CubeState.NotUsed);

                        count++;
                        yield return new WaitForSeconds(_spawnDelay);
                    }
                }
            }
        }

        private void ClearCubes()
        {
            foreach (var cube in _spawnedCubes)
            {
                Destroy(cube);
            }
            _spawnedCubes.Clear();
            _positionsTaken.Clear();
        }

        private void CreateCube(Vector3 currentVector, CubeState state)
        {
            GameObject newCube = Instantiate(_cubePrefab);
            _spawnedCubes.Add(newCube);
            OnSpawnedCube?.Invoke(newCube, state, currentVector);
        }
    }
}