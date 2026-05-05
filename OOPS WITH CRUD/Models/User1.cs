namespace OOPS_WITH_CRUD.Models
{
    public partial class User
    {
        public override string ToString()
        {
            return $"{Id} - {Name} - {Email} - {Phone}";
        }
    }
}