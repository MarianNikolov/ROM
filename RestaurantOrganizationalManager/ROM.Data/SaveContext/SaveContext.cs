namespace ROM.Data.SaveContext
{
    public class SaveContext : ISaveContext
    {
        private readonly RomDbContext context;

        public SaveContext(RomDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
