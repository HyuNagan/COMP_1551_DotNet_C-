using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP1551.QuestionContext
{
    public class Question
    {
        public int Id { get; set; }

        public string Text { get; set; } // Nội dung câu hỏi

        public QuestionType Type { get; set; } // Loại câu hỏi: MCQ, OpenEnded, TrueFalse

        public string Answer { get; set; } // Đáp án đúng (có thể là chữ hoặc "True"/"False")

        // Chỉ dùng cho Multiple Choice
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
    }

}
