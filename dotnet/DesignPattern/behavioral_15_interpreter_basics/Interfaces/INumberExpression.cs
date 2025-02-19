using behavioral_15_interpreter_basics.Models.Common;

namespace behavioral_15_interpreter_basics.Interfaces
{
    public interface INumberExpression
    {
        void Interpret(NumberContext context);
    }
}