using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Physics.Authoring
{
    [CreateAssetMenu(menuName = "Unity Physics/Physics Category Names", fileName = "Physics Category Names",
        order = 507)]
    public sealed class PhysicsCategoryNames : ScriptableObject, ITagNames
    {
        [SerializeField] private string[] m_CategoryNames =
        {
            string.Empty, string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty
        };

        private PhysicsCategoryNames()
        {
        }

        public IReadOnlyList<string> CategoryNames => m_CategoryNames;

        private void OnValidate()
        {
            if (m_CategoryNames.Length != 32)
                Array.Resize(ref m_CategoryNames, 32);
        }

        IReadOnlyList<string> ITagNames.TagNames => CategoryNames;
    }
}