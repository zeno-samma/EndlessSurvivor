using UnityEngine;

namespace MrX.EndlessSurvivor
{
    public class HomePanel : MonoBehaviour
    {

        public void PlayBtn()
        {
            GameManager.Ins.PlayGame();
        }
    }

}
