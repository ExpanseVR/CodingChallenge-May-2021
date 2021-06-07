using SingularHealth.Managers;
using UnityEngine;

namespace SingularHealth.Cube
{
    public class CubeDisplay : MonoBehaviour
    {
        public enum CubeState
        {
            Used,
            NotUsed
        }

        [SerializeField] private Color _usedColor;
        [SerializeField] private Color _notUsedColor;
        [SerializeField] private Renderer _renderer;

        private CubeState _currentState = new CubeState();

        private void Awake()
        {
            SpawnMananger.OnSpawnedCube += SetCube;
        }

        private void SetCube(GameObject cube, CubeState state, Vector3 position)
        {
            if (cube != this.gameObject)
                return;

            _currentState = state;
            transform.position = position;
            SetStateColour();
        }

        private void SetStateColour()
        {
            if (_currentState == CubeState.Used)
                _renderer.material.color = _usedColor;
            else
                _renderer.material.color = _notUsedColor;
        }

        private void OnDisable()
        {
            SpawnMananger.OnSpawnedCube -= SetCube;
        }
    }
}