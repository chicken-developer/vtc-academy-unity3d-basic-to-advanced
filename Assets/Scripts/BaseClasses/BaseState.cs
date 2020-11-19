using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseClass {
    public enum Input {
        EIdle,
        ERun,
        EAttack,
        EDie
    }
    class Context {
        private State _state = null;
        public Context(State state) {
            this.TransitionTo(state);
        }
        public void TransitionTo(State state) {
            this._state = state;
            this._state.SetContext(this);
        }
        public void RequestInput(Input playerInput) {
            this._state.HandleInput(playerInput);
        }
        public void RequestUpdate() {
            this._state.HandleUpdate();
        }
    }
    abstract class State {
        protected Context _context;
        public void SetContext(Context context) {
            this._context = context;
        }
        public abstract void HandleInput(Input playerInput);
        public abstract void HandleUpdate();
    }

    class Idle : State {
        public override void HandleInput(Input playerInput) {
            switch (playerInput) {
                case Input.EIdle:
                    return;
                case Input.ERun:
                    this._context.TransitionTo(new Run());
                    return;
                case Input.EAttack:
                    return;
                case Input.EDie:
                    return;
                default:
                    return;
            }
        }
        public override void HandleUpdate() {
            //TODO: Update for player when is in idling

        }
    }

    class Run : State {
        public override void HandleInput(Input playerInput) {
            switch (playerInput) {
                case Input.EIdle:
                    return;
                case Input.ERun:
                    this._context.TransitionTo(new Run());
                    return;
                case Input.EAttack:
                    return;
                case Input.EDie:
                    return;
                default:
                    return;
            }
        }
        public override void HandleUpdate() {
            //TODO: Update for player when is in running
        }
    }

    class Attack : State {
        public override void HandleInput(Input playerInput) {
            switch (playerInput) {
                case Input.EIdle:
                    return;
                case Input.ERun:
                    this._context.TransitionTo(new Run());
                    return;
                case Input.EAttack:
                    return;
                case Input.EDie:
                    return;
                default:
                    return;
            }
        }
        public override void HandleUpdate() {
           //TODO: Update for player when is in attacking
        }
    }
    class Die : State {
        public override void HandleInput(Input playerInput) {
            switch (playerInput) {
                case Input.EIdle:
                    return;
                case Input.ERun:
                    this._context.TransitionTo(new Run());
                    return;
                case Input.EAttack:
                    return;
                case Input.EDie:
                    return;
                default:
                    return;
            }
        }
        public override void HandleUpdate() {
            //TODO: Update for player when is in dying
        }
    }
}

