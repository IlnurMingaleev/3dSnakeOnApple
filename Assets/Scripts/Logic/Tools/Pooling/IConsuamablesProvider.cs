using System;
using Logic.Consumables.Views;

namespace Logic.Tools.Pooling
{
    public interface IConsuamablesProvider
    {
        IConsumableView CurrentConsumable { get; }
        IConsumableView Get(Action<IConsumableView> OnConsumed , IConsumableView consumedApple);
        void Init(Action<IConsumableView> OnConsumed );
    }
}