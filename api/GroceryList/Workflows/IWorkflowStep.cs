using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTracker.Workflows
{
    interface IWorkflowStep
    {
        IWorkflowStepOptions HandleRequest(IWorkflowStepOptions input);

    }

    public interface IWorkflowStepOptions
    {

    }

    public class WorkflowStepValidationException: Exception
    {
        public WorkflowStepValidationException(string message) : base(message)
        {

        }
    }
}
