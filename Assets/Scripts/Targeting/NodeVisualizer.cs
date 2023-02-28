using TakeArms.Systems;
using UnityEngine;

namespace TakeArms.Targeting
{
    public class NodeVisualizer : MonoBehaviour
    {
        private Material _material;

        private void Awake()
        {
            _material = GetComponent<Material>();
        }
        public void ShowAt(Vector3 pos)
        {
            transform.position = pos;
        }
        public void SetColor(Color color)
        {
            _material.color = color;
        }

    }
}
