namespace Todo
{
    public class Todo
    {
        public string Description { get; set; }

        public void Validate()
        {
            if (Description == null)
                throw new DescriptionRequiredException();
        }
    }
}