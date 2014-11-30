using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceAcademy.DBModels
{
    [Table("QuestionsWithAnswers")]
    public class QuestionsWithAnswers
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Unique, MaxLength(150)]
        public string Question { get; set; }

        public string AnswerOne { get; set; }

        public string AnswerTwo { get; set; }

        public string AnswerThree{ get; set; }

        [NotNull]
        public int RightAnswer { get; set; }
    }
}
