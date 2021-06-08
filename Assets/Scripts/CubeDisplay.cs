using SingularHealth.Managers;
using SingularHealth.Shader;
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

        [SerializeField] private Color     _usedColor;
        [SerializeField] private Color     _usedHitColor;
        [SerializeField] private Color     _notUsedColor;
        [SerializeField] private Color     _notUsedHitColor;
        [SerializeField] private Renderer  _renderer;
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private HitDetectionShaderController _shaderControl;

        private CubeState _currentState = new CubeState();
        private Vector3 _startPosition;

        private void Awake()
        {
            SpawnMananger.OnSpawnedCube += SetCube;
            SpawnMananger.OnCubeReset += ResetPosition;
        }

        private void SetCube(GameObject cube, CubeState state, Vector3 position)
        {
            if (cube != this.gameObject)
                return;

            _currentState = state;
            _startPosition = position;
            transform.position = position;
            SetStateColour();
        }

        private void SetStateColour()
        {
            if (_currentState == CubeState.Used)
                _shaderControl.SetColor(_usedColor, _usedHitColor);
            else
                _shaderControl.SetColor(_notUsedColor, _notUsedHitColor);
        }

        private void ResetPosition()
        {
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.position = _startPosition;
        }

        private void OnDisable()
        {
            SpawnMananger.OnSpawnedCube -= SetCube;
            SpawnMananger.OnCubeReset -= ResetPosition;
        }
    }
}