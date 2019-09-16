namespace Penguin.Cms.Security.Static
{
    public partial class Roles
    {
        /// <summary>
        /// A role assigned to all users in the system regardless of context
        /// </summary>
        public static Role AllUsers => new Role()
        {
            Name = Names.AllUsers,
            Description = Descriptions.AllUsers
        };
    }
}