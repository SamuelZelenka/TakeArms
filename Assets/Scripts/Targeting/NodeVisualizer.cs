using TakeArms.Systems;
using UnityEngine;

namespace TakeArms.Targeting
{
    public class NodeVisualizer : MonoBehaviour
    {
        private MeshRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }
        public void ShowAt(Vector3 pos)
        {
            transform.position = pos;
        }
        public void SetColor(Color color)
        {
            _renderer.material.color = color;
        }

    }
}
