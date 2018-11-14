using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class EventFadeComplete : UnityEvent<bool> { }
    //[System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
    [System.Serializable] public class EventEnemyDeath : UnityEvent{}
    [System.Serializable] public class EventIntegerEvent : UnityEvent<int> {}

}