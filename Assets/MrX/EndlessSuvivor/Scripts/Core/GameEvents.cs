using UnityEngine;

namespace MrX.EndlessSurvivor
{
    // Ví dụ một sự kiện không chứa dữ liệu
    public struct GameStartedEvent { }
    public struct StateUpdatedEvent
    {
        public GameManager.GameState CurState;
    }
    public struct PlayerHealthChangedEvent
    {
        public float NewHealthPercentage;
    }
    public struct SendToWaveSpawner { }

    public struct EnemyDiedEvent
    {
        public int diecoin;
    }
        

    public struct InitialUIDataReadyEvent
    {
        // public int defHealth;
        // public int maxHealth;
        // public int defScore;
    }
    
}