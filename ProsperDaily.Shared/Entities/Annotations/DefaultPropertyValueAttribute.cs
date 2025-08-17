namespace ProsperDaily.Shared.Entities.Annotations;

[AttributeUsage(AttributeTargets.Property)]
public class DefaultPropertyValueAttribute(object value) : Attribute
{
    public object DefaultValue => value;
}
