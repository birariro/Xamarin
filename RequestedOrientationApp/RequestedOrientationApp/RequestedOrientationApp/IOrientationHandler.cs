using System;
using System.Collections.Generic;
using System.Text;

namespace RequestedOrientationApp
{
    public interface IOrientationHandler
    {
        void ForceLandscape();

        void ForcePortrait();
    }
}
