using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Model
{
    public class TrainList
    {
        public class AllBody
        {
            public int AllBodyID { get; private set; }
            public string ImagePath { get; set; }
            public string NameExercise { get; set; }
            public int Count { get; set; }
        }
        public class GrudAndBiceps
        {
            public int GrudAndBicepsID { get; private set; }
            public string ImagePath { get; set; }
            public string NameExercise { get; set; }
            public int Count { get; set; }
        }
        public class Press
        {
            public int PressID { get; private set; }
            public string ImagePath { get; set; }
            public string NameExercise { get; set; }
            public int Count { get; set; }
        }
        public class SpinaAndTriceps
        {
            public int SpinaAndTricepsID { get; private set; }
            public string ImagePath { get; set; }
            public string NameExercise { get; set; }
            public int Count { get; set; }
        }
        public class NogiAndPlechi
        {
            public int NogiAndPlechiID { get; private set; }
            public string ImagePath { get; set; }
            public string NameExercise { get; set; }
            public int Count { get; set; }
        }
    }
}
