using Quelos;
using Quelos.Mathematics;

namespace Sandbox
{
    public class CameraController : Entity
    {
        public float DistanceFromPlayer = 10f;
        public float SnappingSpeed = 2f;
        
        private Player m_Player;
        private float m_CurrentDistance;

        private void OnStart()
        {
            m_Player = FindEntityByName("Player").As<Player>();
            m_CurrentDistance = DistanceFromPlayer;
        }

        private void OnUpdate(float ts)
        {
            if (!m_Player)
            {
                print("Player is null! trying to find the entity...");
                m_Player = FindEntityByName("Player").As<Player>();
                return;
            }

            float target = DistanceFromPlayer + math.len(m_Player.Rigidbody.Velocity);
            m_CurrentDistance = math.lerp(m_CurrentDistance, target, ts * SnappingSpeed);

            Transform.Position = new float3(m_Player.Position.xy, m_CurrentDistance);
        }
    }
}
