using Infrustructure.Factory;
using Infrustructure.StateMachine.Data;

namespace Infrustructure.StateMachine
{
    public interface IGameRunner
    {
        void Init(IDataBetweenStates dataBetweenStates, IGameObjectFactory gameObjectFactory);
    }
}