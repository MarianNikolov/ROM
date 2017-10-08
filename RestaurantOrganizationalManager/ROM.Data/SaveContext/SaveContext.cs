namespace ROM.Data.SaveContext
{
    public class SaveContext : ISaveContext
    {
        private readonly DbContext context;

        public SaveContext(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
