namespace Forge.Domain.Types;

public abstract class StronglyTypedValue<T> : IEquatable<StronglyTypedValue<T>> where T : IComparable<T>
{
    public T Value { get; }

    protected StronglyTypedValue(T value)
    {
        this.Value = value;
    }

    public bool Equals(StronglyTypedValue<T>? other)
    {
        if (object.ReferenceEquals(null, other))
        {
            return false;
        }

        if (object.ReferenceEquals(this, other))
        {
            return true;
        }

        return EqualityComparer<T>.Default.Equals(this.Value, other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (object.ReferenceEquals(null, obj))
        {
            return false;
        }

        if (object.ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != this.GetType())
        {
            return false;
        }

        return Equals((StronglyTypedValue<T>)obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(this.Value);
    }

    public static bool operator ==(StronglyTypedValue<T>? left, StronglyTypedValue<T>? right)
    {
        return object.Equals(left, right);
    }

    public static bool operator !=(StronglyTypedValue<T>? left, StronglyTypedValue<T>? right)
    {
        return !object.Equals(left, right);
    }
}
