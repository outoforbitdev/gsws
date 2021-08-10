using System;

namespace GSWS.Model
{
    public class Entity: IEquatable<Entity>
    {
        public string Name { get; set; }
        public string Environment { get; set; }

        public Entity()
        {
            Name = "";
            Environment = "";
        }

        public override bool Equals(object obj)
        {
            if (obj is Entity)
            {
                return Equals((Entity)obj);
            }
            return false;
        }
        public bool Equals(Entity b)
        {
            if (b is null)
            {
                return false;
            }
            return Name == b.Name && Environment == b.Environment;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null)
            {
                return b is null;
            }
            return a.Equals(b);
        }
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
    }
}
