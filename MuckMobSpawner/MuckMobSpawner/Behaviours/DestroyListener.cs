using MuckMobLoader.Core;
using UnityEngine;

namespace MuckMobLoader.Behaviours
{
    internal class DestroyListener : MonoBehaviour
    {
        private void OnDestroy()
        {
            MenuController.menuController = null;
        }
    }
}
