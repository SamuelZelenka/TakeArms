using UnityEngine;

namespace TakeArms.Utility
{
    public class ZGameObjectPool<T> : ZObjectPool<MonoBehaviour> where T : MonoBehaviour
    {
        private T prefab;
        private Transform parent;

        public override MonoBehaviour Acquire()
        {
            T acquired = base.Acquire() as T;
            acquired.gameObject.SetActive(true);
            return acquired;
        }

        public override void Release(MonoBehaviour releaseObject)
        {
            if (GetPoolSize() > capacity)
            {
                Object.Destroy(releaseObject);
                return;
            }
            pool.Enqueue(releaseObject);
            releaseObject.gameObject.SetActive(false);
        }

        public ZGameObjectPool(T prefab, Transform parent)
        {
            this.parent = parent;
            this.prefab = prefab;
            OnCreate = () => Object.Instantiate(prefab, parent);
        }
    }
}
