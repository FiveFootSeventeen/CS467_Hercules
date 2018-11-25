using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [System.Serializable]
    public class EventFadeComplete : UnityEvent<bool> { }    
    //public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }    
    public class EventEnemyDeath : UnityEvent { }   
    public class EventIntegerEvent : UnityEvent<int> { }
}