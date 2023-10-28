using UnityEngine;

namespace Infrustructure.Factory
{
    public class HudView : MonoBehaviour
    {
        private string hudName;

        public void Initialize( string name)
        {
            hudName = name;
        }
    }
}