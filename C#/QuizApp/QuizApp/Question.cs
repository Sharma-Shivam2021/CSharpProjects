namespace QuizApp;

internal class Question
{
    public string QuestionText { get; }
    public string[] Answers { get; }

    public int CorrectAnswerIndex { get; }

    public Question(string questionText, string[] answers, int correctAnswerIndex)
    {
        QuestionText = questionText;
        Answers = answers;
        CorrectAnswerIndex = correctAnswerIndex;
    }

    public bool IsCorrectAnswer(int choice)
    {
        return choice == CorrectAnswerIndex;
    }
}
