using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

namespace Es.uSpringBone
{
    /// <summary>
    /// Collision data.
    /// </summary>
    public struct ColliderData : ISharedComponentData
    {
        public float radius;
        public float3 grobalPosition;

        public ColliderData(float radius, Vector3 grobalPosition)
        {
            this.radius = radius;
            this.grobalPosition = grobalPosition;
        }
    }

    /// <summary>
    /// Collision determination component.
    /// </summary>
    [ScriptExecutionOrder(-30000)]
    public class SpringBoneCollider : SharedComponentDataWrapper<ColliderData>
    {
        public float radius;
        public ColliderData data;

        Transform cachedTransform;

        void Start()
        {
            cachedTransform = transform;
            data = new ColliderData(radius, transform.position);
        }

        void Update()
        {
            data.radius = radius;
            data.grobalPosition = cachedTransform.position;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}