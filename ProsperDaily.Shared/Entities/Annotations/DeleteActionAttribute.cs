using Microsoft.EntityFrameworkCore;

namespace ProsperDaily.Shared.Entities.Annotations;

[AttributeUsage(AttributeTargets.Property)]
public class DeleteActionAttribute(DeleteBehavior deleteBehavior) : Attribute
{
    public DeleteBehavior DeleteBehavior => deleteBehavior;
}
