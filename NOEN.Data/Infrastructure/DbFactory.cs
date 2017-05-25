namespace NOEN.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NOENdbContext dbContext;

        public NOENdbContext Init()
        {
            //Kiểm tra nếu null sẽ khởi tạo new mới.
            return dbContext ?? (dbContext = new NOENdbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}