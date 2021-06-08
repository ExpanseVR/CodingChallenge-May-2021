using System.Collections;
using UnityEngine;

namespace SingularHealth.Shader
{
    public class HitDetectionShaderController : MonoBehaviour
    {
        private MaterialPropertyBlock _matPropertyBlock;
        private Renderer _renderer;

        private const int MaxHitCounts = 10;

        private Vector4[] _hitsObjectPosition = new Vector4[MaxHitCounts];
        private float[]   _hitsTimer          = new float[MaxHitCounts];
        private float[]   _hitsIntensity      = new float[MaxHitCounts];
        private float[]   _hitRadius          = new float[MaxHitCounts];
        private float     _hitsDuration       = 8f;
        private int       _hitsCount;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _matPropertyBlock = new MaterialPropertyBlock();
        }

        void Update()
        {
            SendHitsToRenderer();
        }

        public void SetColor(Color mainColor, Color hitColor)
        {
            _renderer.GetPropertyBlock(_matPropertyBlock);
            _matPropertyBlock.SetColor("_MainColor", mainColor);
            _matPropertyBlock.SetColor("_HitColor", hitColor);
            _renderer.SetPropertyBlock(_matPropertyBlock);
        }

        public void AddHit(Vector3 worldPosition)
        {
            int id = GetHitId();
            _hitsObjectPosition[id] = transform.InverseTransformPoint(worldPosition);
            _hitsTimer[id] = 0;
            _hitRadius[id] = 5;

            StartCoroutine(BeginHit(id));
        }
        private int GetHitId()
        {
            if (_hitsCount < MaxHitCounts)
                _hitsCount++;
            else
                _hitsCount = 1;
            return _hitsCount - 1;
        }

        IEnumerator BeginHit(int hitID)
        {
            while (_hitsTimer[hitID] < _hitsDuration)
            {
                _hitsTimer[hitID] += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }

        private void SendHitsToRenderer()
        {
            for (int i = 0; i < _hitsCount; i++)
            {
                _hitsIntensity[i] = 1 - Mathf.Clamp01(_hitsTimer[i] / _hitsDuration);
            }
            _renderer.GetPropertyBlock(_matPropertyBlock);
            _matPropertyBlock.SetFloat("_HitsCount", _hitsCount);
            _matPropertyBlock.SetFloatArray("_HitsRadius", _hitRadius);
            _matPropertyBlock.SetVectorArray("_HitsObjectPosition", _hitsObjectPosition);
            _matPropertyBlock.SetFloatArray("_HitsIntensity", _hitsIntensity);
            _renderer.SetPropertyBlock(_matPropertyBlock);
        }
    }
}