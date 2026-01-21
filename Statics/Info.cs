namespace WebApiFormApp.Statics
{
    public static class Info
    {
        public static Guid ID { get; private set; }

        public static void SetID(Guid id)
        {
            ID = id;
        }


    }
}
