using UnityEngine;

namespace Infrustructure.Services.Input
{
  public abstract class InputService
  {
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    private const string Button = "Fire";
    
    public abstract Vector2 Axis { get; }
    

    protected static Vector2 SimpleInputAxis()
    {
      return new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
     
  }
}