using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   public StateMachine StateMachine { get; private set; }
   [field:SerializeField] public Animator Anim { get; private set; }
   [field:SerializeField] public Rigidbody2D Rigi { get; private set; }
   [field:SerializeField] public InputActionReference MoveInput { get; private set; }
   public IdleState IdleState { get; private set; }
   public RunState RunState { get; private set; }
   private void Awake()
   {
      StateMachine = new StateMachine();
      IdleState = new IdleState(this);
      RunState = new RunState(this);
   }

   private void Start()
   {
      StateMachine.ForceSetState(IdleState);
   }

   private void Update()
   {
      StateMachine.Tick();
   }

   private void FixedUpdate()
   {
      StateMachine.FixedTick();
   }
}
