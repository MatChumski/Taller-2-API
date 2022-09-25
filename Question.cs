namespace Taller_2___API
{
    public class Question
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public List<String> Answers { get; set; }

        public int RightAnswer { get; set; }
    }
}
