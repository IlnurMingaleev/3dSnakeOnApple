using UnityEngine;

namespace Infrustructure.Services.Input
{
  public class StandaloneInputService : InputService, IInputService
  {
    public override Vector2 Axis
    {
      get
      {
        Vector2 axis = SimpleInputAxis();

        if (axis == Vector2.zero)
        {
          axis = UnityAxis();
        }

        return axis;
      }
    }
    
    public bool CanWeCalculateInput()
    {
      return true;
    }

    private static Vector2 UnityAxis()
    {
      return new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
  }
}