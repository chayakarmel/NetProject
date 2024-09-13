
namespace IBL
{
    public interface Ibl
    {
        public object Get(int id);
        public List<object> GetAll(Func<object, bool>? condition = null);
        public bool Add(object item);
        public bool Update(object item);
        public bool Delete(int id);
    }
}