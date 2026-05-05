namespace OOPS_WITH_CRUD.Models
{
    public partial class User
    {
        public override string ToString()
        {
            return $"{Id}\nName: {Name}\nEmail: {Email}\nPhone: {Phone}";
        }
    }
}