using System.Collections;
using UnityEngine;

namespace MrX.EndlessSurvivor
{
    public class WaveSpawner : MonoBehaviour
    {
        public Transform[] spawnPoints;
        private void OnEnable()
        {

            // Đăng ký lắng nghe sự thay đổi trạng thái từ GameManager
            EventBus.Subscribe<SendToWaveSpawner>(OnSendToWaveSpawner);//Lắng nghe trạng thái game do gamemanager quản lý
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<SendToWaveSpawner>(OnSendToWaveSpawner);
        }

        private void OnSendToWaveSpawner(SendToWaveSpawner spawner)
        {
           Debug.Log("GameStart...!");
           StartCoroutine(SpawnEnemies(1, 5f));//count, level,Delaytime  
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
                Debug.Log("Spawn-GiantFlam");
                yield return new WaitForSeconds(spawnInterval);
            }
            Debug.Log("Đã spawn xong, đang chờ người chơi dọn dẹp...");
            yield break; // Kết thúc coroutine cho wave này
        }
    }
}

