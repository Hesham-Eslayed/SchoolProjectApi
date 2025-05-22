namespace SchoolProject.Domain.AppMetaData;
public abstract partial class Router
{
    public abstract class Department
    {
        private const string Prefix = root + "Department";
        public const string List = Prefix;
        public const string GetById = Prefix + "/id";
        public const string Add = Prefix + "/add";
        public const string Update = Prefix + "/update";
        public const string Delete = Prefix + singleRout;
        public const string Paginated = Prefix + "/Paginated";
    }
}
