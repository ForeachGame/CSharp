namespace HomeWork8._2
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Ответ (да/нет)
        /// </summary>
        public bool TrueFalse { get; set; }

        public Question(string text, bool trueFalse)
        {
            Text = text;
            TrueFalse = trueFalse;
        }

        public Question() { }

    }
}
