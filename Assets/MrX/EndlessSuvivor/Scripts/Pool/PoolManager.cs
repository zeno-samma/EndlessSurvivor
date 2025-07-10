using System.Collections.Generic;
using UnityEngine;

namespace MrX.EndlessSurvivor
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Ins { get; private set; }
        // Một class nhỏ để cấu hình mỗi pool trong Inspector cho tiện
        [System.Serializable]
        public class PoolConfig
        {
            public string tag;          // Tên định danh cho pool (ví dụ: "PlayerBullet", "BasicEnemy")
            public GameObject prefab;   // Prefab của đối tượng
            public int initialSize;    // Số lượng đối tượng muốn tạo sẵn
        }

        [Header("Pool Configuration")]
        public List<PoolConfig> poolConfigs; // Danh sách tất cả các pool bạn muốn tạo

        // Dictionary để lưu trữ và truy cập các pool bằng tag
        private Dictionary<string, MyPool> pools;

        void Awake()
        {
            // Singleton Pattern
            if (Ins != null && Ins != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Ins = this;
            }
            pools = new Dictionary<string, MyPool>();
            foreach (var config in poolConfigs)
            {
                MyPool newPool = new MyPool(config.prefab);
                // Tạo sẵn các object và để chúng ở trạng thái "tắt"
                for (int i = 0; i < config.initialSize; i++)
                {
                    GameObject objToWarm = newPool.Get(false);
                }
                pools.Add(config.tag, newPool);
                // Debug.Log($"Pool with tag '{config.tag}' created with {config.initialSize} objects.");
            }
        }

        public GameObject GetFromPool(string tag)
        {
            // Kiểm tra xem có pool nào với tag được yêu cầu không
            if (!pools.ContainsKey(tag))
            {
                Debug.LogWarning($"Pool with tag '{tag}' doesn't exist.");
                return null;
            }

            // Nếu có, lấy một object từ pool đó và trả về
            // Tham số 'true' đảm bảo object sẽ được SetActive(true)
            return pools[tag].Get(true);
        }
    }
}

