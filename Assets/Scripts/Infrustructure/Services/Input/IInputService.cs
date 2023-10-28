using UnityEngine;

namespace Infrustructure.Services.Input
{
  public interface IInputService : IService
  {
    Vector2 Axis { get; }

    bool CanWeCalculateInput();

  }
}