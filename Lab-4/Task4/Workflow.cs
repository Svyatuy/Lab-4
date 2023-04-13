using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Workflow
    {
        public event EventHandler<ActionEventArgs> ActionAdded;
        public event EventHandler<ActionEventArgs> ActionCompleted;
        public event EventHandler WorkflowCompleted;

        private enum State
        {
            AddAction,
            ExecuteAction,
            WorkflowComplete
        }

        private State currentState = State.AddAction;

        public void Run()
        {
            var action1 = new Action("Action 1");
            var action2 = new Action("Action 2");
            var action3 = new Action("Action 3");

            AddAction(action1);
            AddAction(action2);
            AddAction(action3);

            while (currentState != State.WorkflowComplete)
            {
                switch (currentState)
                {
                    case State.AddAction:
                        currentState = State.ExecuteAction;
                        break;
                    case State.ExecuteAction:
                        action1.Execute();
                        action2.Execute();
                        action3.Execute();
                        currentState = State.WorkflowComplete;
                        break;
                }
            }

            OnWorkflowCompleted();
        }

        private void AddAction(Action action)
        {
            OnActionAdded(action);
            OnActionCompleted(action);
        }

        protected virtual void OnActionAdded(Action action)
        {
            ActionAdded?.Invoke(this, new ActionEventArgs(action));
        }

        protected virtual void OnActionCompleted(Action action)
        {
            ActionCompleted?.Invoke(this, new ActionEventArgs(action));
        }

        protected virtual void OnWorkflowCompleted()
        {
            WorkflowCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
