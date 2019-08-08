namespace Penguin.Cms.Security.Interfaces
{
    /// <summary>
    /// Tells the Penguin CMS initialization system that the properties on the object using this represent roles that
    /// should be persisted to the database on initialization. This should be changed to a generic type with a type parameter of 
    /// "Role" that implements IEnumerable, and is retrieved by reflection (GetDerivedType)
    /// </summary>
    public interface IDefaultRoles
    {
    }
}