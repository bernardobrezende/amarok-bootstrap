namespace Amarok.Bootstrap.Domain.Entities
{
    public class Feature : Entity
    {
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; protected set; }

        protected Feature() { }

        public Feature(string name, bool isActive)
        {
            this.Name = name;
            this.IsActive = isActive;
        }
    }
}