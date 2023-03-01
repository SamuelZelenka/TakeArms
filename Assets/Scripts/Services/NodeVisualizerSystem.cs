using UnityEngine;
using TakeArms.Utility;
using TakeArms.Targeting;
using TakeArms.Systems;

namespace TakeArms.Services
{
    public static class NodeVisualizerSystem
    {
        private static ZGameObjectPool<NodeVisualizer> _nodePool = new ZGameObjectPool<NodeVisualizer>(RepositoryService.NodeVisualizerPrefab, null);
        private static NodeVisualizer _mouseNode = _nodePool.Acquire().GetComponent<NodeVisualizer>();

        public static void UpdateMouseNodeVisualizer(Vector2Int nodeCoordinate)
        {
            _mouseNode.ShowAt(GameBoard.GetWorldPosFromBoardPos(nodeCoordinate));
            if (GameUnitSystem.GetGameUnitAt(nodeCoordinate) != 0)
            {
                _mouseNode.SetColor(Color.green);
            }
            else
            {
                _mouseNode.SetColor(Color.white);
            }
        }
    }
}