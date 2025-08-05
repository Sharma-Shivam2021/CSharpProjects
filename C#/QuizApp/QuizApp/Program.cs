using QuizApp;

Question[] questions = new Question[]
{
    new Question("What is the capital of India",
       new string[] {"Paris","Berlin","London","New Delhi" },
        3
    ),
     new Question("Which planet is known as the Red Planet?",
        new string[] {"Earth", "Mars", "Jupiter", "Venus" },
        1
    ),
    new Question("Who wrote 'Romeo and Juliet'?",
        new string[] { "Charles Dickens", "William Shakespeare", "Jane Austen", "Mark Twain" },
        1
    ),
    new Question("What is the largest ocean on Earth?",
        new string[] { "Atlantic Ocean", "Indian Ocean", "Arctic Ocean", "Pacific Ocean" },
        3
    ),
    new Question("Which element has the chemical symbol 'O'?",
        new string[] { "Gold", "Oxygen", "Silver", "Iron" },
        1
    ),
};

Quiz quiz = new Quiz(questions);

quiz.StartQuiz(); 

Console.ReadLine();