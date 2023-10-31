using Helpers;
using Infrustructure.MVC;
using UnityEngine;

namespace Infrustructure.Services.Input
{
  public interface IMobileInputService
  {
    VariableJoystick VariableJoystick { get; }
    Vector2 Axis { get; }
    void InitializeJoystick();
    bool CanWeCalculateInput();
  }

  public class MobileInputService : InputService, IMobileInputService
  {
    private VariableJoystick _variableJoystick;

    public VariableJoystick VariableJoystick { get => _variableJoystick; }

    public void InitializeJoystick()
    {
      _variableJoystick = Object.FindObjectOfType<MobileInputView>().variableJoystick;
    }

    public override Vector2 Axis => new Vector2(_variableJoystick.Horizontal,
      _variableJoystick.Vertical);

    public bool CanWeCalculateInput()
    {
      return (_variableJoystick.Direction.magnitude > Constants._zero);
    }
  }


}