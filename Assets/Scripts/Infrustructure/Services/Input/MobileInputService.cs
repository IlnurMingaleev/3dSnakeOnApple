using Infrustructure.MVC;
using UnityEngine;

namespace Infrustructure.Services.Input
{
  public class MobileInputService : InputService, IInputService
  {
    private IMobileInputView _mobileInputView;

    public void InitializeJoystick()
    {
      _mobileInputView = Object.FindObjectOfType<MobileInputView>();
    }

    public override Vector2 Axis => new Vector2(_mobileInputView.variableJoystick.Horizontal,
      _mobileInputView.variableJoystick.Vertical);

    public bool CanWeCalculateInput()
    {
      return (_mobileInputView.variableJoystick.Direction.magnitude > 0);
    }
  }


}