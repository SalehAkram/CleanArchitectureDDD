using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalCare.Core
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        public bool Equals(Entity<TId>? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }
        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
