namespace LifetimeExamples.Services
{
    public class Repository
    {
        private readonly DatabaseContext _dataContext;
        public Repository(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int RowCount => _dataContext.RowCount;
    }

    public class ScopedRepository : Repository
    {
        public ScopedRepository(ScopedDataContext generator) : base(generator) { }
    }

    public class TransientRepository : Repository
    {
        public TransientRepository(TransientDataContext generator) : base(generator) { }
    }

    public class SingletonRepository : Repository
    {
        public SingletonRepository(SingletonDataContext generator) : base(generator) { }
    }

    public class CapturingRepository : Repository
    {
        public CapturingRepository(ScopedDataContext generator) : base(generator) { }
    }
}
