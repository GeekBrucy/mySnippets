namespace behavioral_16_mediator_basics.Models.Good
{
    public class CustomMenuItem : Element
    {
        public CustomMenuItem(Mediator mediator) : base(mediator)
        {
        }

        public void Click()
        {
            OnChange();
        }
    }
}