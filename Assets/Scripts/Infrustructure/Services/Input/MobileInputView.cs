using UnityEngine;

namespace Infrustructure.Services.Input
{
    public class MobileInputView : MonoBehaviour, IMobileInputView
    {
        [SerializeField] private VariableJoystick _variableJoystick;
        public VariableJoystick variableJoystick 
        { 
            get => _variableJoystick;

        }
        
        
    }
}