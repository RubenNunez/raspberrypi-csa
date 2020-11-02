using System.Collections.Generic;
using System.Drawing;

namespace CSA_GAME.Engine
{
    public abstract class GameObject
    {
        public Transform Transform;
        public List<GameObject> Children = new List<GameObject>();

        public virtual void Start()
        {
            foreach (var child in Children)
                child.Start();
        }
        public virtual void Update(Graphics ctx, long deltaTime)
        {
            foreach (var child in Children)
                child.Update(ctx, deltaTime);
        }
    }
}
