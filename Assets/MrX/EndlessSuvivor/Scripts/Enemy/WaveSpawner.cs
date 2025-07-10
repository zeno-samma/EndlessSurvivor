using System.Collections;
using UnityEngine;

namespace MrX.EndlessSurvivor
{
    public class WaveSpawner : MonoBehaviour
    {
        public Transform[] spawnPoints;
        void Start()
        {

            StartCoroutine(SpawnEnemies(5, 20f));//count, level,Delaytime
        }
        private IEnumerator SpawnEnemies(int count, float spawnInterval)
        {
            for (int i = 0; i < count; i++)
            {
                // Lấy một chỉ số ngẫu nhiên từ 0 đến số lượng điểm spawn
                int randomIndex = Random.Range(0, spawnPoints.Length);

                // Lấy Transform của điểm spawn ngẫu nhiên đó
                Transform randomSpawnPoint = spawnPoints[randomIndex];
                PoolManager.Ins.GetFromPool("GiantFlam",randomSpawnPoint.position);
                yield return new WaitForSeconds(spawnInterval);
            }
            Debug.Log("Đã spawn xong, đang chờ người chơi dọn dẹp...");
            yield break; // Kết thúc coroutine cho wave này
        }
    }
}

