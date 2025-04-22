namespace SchoolProject.Domain.AppMetaData;
public abstract partial class Router
{
    public abstract class Student
    {
        private const string Prefix = root + "Students";
        public const string List = Prefix;
        public const string GetById = Prefix + "/{id}";
    }
}
