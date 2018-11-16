<<<<<<< HEAD
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class EventFadeComplete : UnityEvent<bool> { }
    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
    [System.Serializable] public class EventEnemyDeath : UnityEvent{}
    [System.Serializable] public class EventIntegerEvent : UnityEvent<int> {}

=======
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class EventFadeComplete : UnityEvent<bool> { }
    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
    [System.Serializable] public class EventEnemyDeath : UnityEvent{}
    [System.Serializable] public class EventIntegerEvent : UnityEvent<int> {}

>>>>>>> f2c982e2f750d0a51bfc32e40765f5a0880ea9fc
}