using SingularHealth.Shader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SingularHealth.Cube
{
    public class CubeBehaviour : MonoBehaviour
    {
        [SerializeField] private HitDetectionShaderController _shaderControl;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Projectile")
                _shaderControl.AddHit(collision.contacts[0].point);
        }
    }
}