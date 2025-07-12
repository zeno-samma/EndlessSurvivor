using System;
using TMPro;
using UnityEngine;

namespace MrX.EndlessSurvivor
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldTxt;
        private void OnEnable()
        {

            // Đăng ký lắng nghe sự thay đổi trạng thái từ GameManager
            EventBus.Subscribe<EnemyDiedEvent>(OnEnemyDiedEvent);//Lắng nghe trạng thái game do gamemanager quản lý
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<EnemyDiedEvent>(OnEnemyDiedEvent);
        }

        private void OnEnemyDiedEvent(EnemyDiedEvent value)
        {
            goldTxt.SetText("{0}",value.diecoin);
        }
    }
}