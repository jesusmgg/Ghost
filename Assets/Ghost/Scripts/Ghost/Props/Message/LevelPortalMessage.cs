using Ghost.Props.Interactable;

namespace Ghost.Props.Message
{
    public class LevelPortalMessage : Message
    {
        public LevelPortal portal;
        
        void Update()
        {
            message = $"(Z) to enter (-(Life){portal.cost}).";
        }
    }
}