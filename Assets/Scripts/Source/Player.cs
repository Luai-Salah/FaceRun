using Quelos;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Player : Entity
    {
        public float Speed = 20f;
        public float StartDelay = 3f;

        private float Timer;

        public Rigidbody2D Rigidbody { get; private set; }

        private void OnStart()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.Type = Rigidbody2D.BodyType.Static;
        }

        private void OnUpdate(float ts)
        {
            Timer += ts;

            if (Timer < StartDelay)
                return;
            else if (Rigidbody.Type != Rigidbody2D.BodyType.Dynamic)
            {
                Rigidbody.Type = Rigidbody2D.BodyType.Dynamic;
            }

            float2 velocity = float2.zero;

            if (Input.GetKey(KeyCode.D))
                velocity.x = 1f;
            if (Input.GetKey(KeyCode.A))
                velocity.x = -1f;

            velocity *= Speed * ts;
            Rigidbody.ApplyLinearImpulse(velocity);
        }
    }
}
