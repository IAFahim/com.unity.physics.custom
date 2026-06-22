using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Physics.Authoring
{
    [RequireComponent(typeof(PhysicsBodyAuthoring))]
    public abstract class BaseJoint : MonoBehaviour
    {
        [SerializeField] [Tooltip("Specifies the type of solver to be used for this joint.")]
        private SolverType m_SolverType = SolverType.Iterative;

        public PhysicsBodyAuthoring ConnectedBody;

        public bool EnableCollision;
        public float3 MaxImpulse = float.PositiveInfinity;

        /// <summary>
        ///     Specifies the type of solver to be used for this joint.
        /// </summary>
        public SolverType SolverType
        {
            get => m_SolverType;
            set => m_SolverType = value;
        }

        public PhysicsBodyAuthoring LocalBody => GetComponent<PhysicsBodyAuthoring>();

        public RigidTransform worldFromA => LocalBody == null
            ? RigidTransform.identity
            : Math.DecomposeRigidBodyTransform(LocalBody.transform.localToWorldMatrix);

        public RigidTransform worldFromB => ConnectedBody == null
            ? RigidTransform.identity
            : Math.DecomposeRigidBodyTransform(ConnectedBody.transform.localToWorldMatrix);


        public Entity EntityA { get; set; }

        public Entity EntityB { get; set; }

        private void OnEnable()
        {
            // included so tick box appears in Editor
        }
    }
}