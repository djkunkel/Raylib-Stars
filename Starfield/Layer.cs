using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfield
{
    internal abstract class Layer: IDisposable
    {
        public abstract void Init(int width, int height);
        public abstract void Update(float frameTime);
        public abstract void Draw();

        public virtual void Dispose()
        {
           
        }
    }
}
