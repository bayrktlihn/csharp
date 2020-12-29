using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odeeev.entity
{
    public class Student
    {

        private int _number;
        private double _visaNote;
        private double _finalNote;

        public int Number { get => _number; set{
                if (value >= 0)
                    _number = value;
                else
                    throw new ArgumentOutOfRangeException();
                
            } }
        public double VisaNote { get => _visaNote; set {
                if (IsValidNote(value))
                    _visaNote = value;
                else
                    throw new ArgumentOutOfRangeException();
            } }
        public double FinalNote { get => _finalNote; set {
                if (IsValidNote(value))
                    _finalNote = value;
                else
                    throw new ArgumentOutOfRangeException();
            } }

        public bool IsValidNote(double note)
        {
            return note >= 0 && note <= 100;
        }

        public double GetNoteAvg()
        {
            return VisaNote * 0.4 + FinalNote * 0.6;
        }

        public bool IsPass
        {
            get
            {
                return GetNoteAvg() >= 40;
            }
        }

        public String LetterNote
        {
            get
            {
                double noteAvg = GetNoteAvg();

                if(noteAvg >= 0 && noteAvg < 20)
                {
                    return "ee";
                }
                else if(noteAvg >= 20 && noteAvg < 40)
                {
                    return "ff";
                } else if(noteAvg >= 40 && noteAvg < 50)
                {
                    return "dd";
                } else if(noteAvg >= 50 && noteAvg < 65)
                {
                    return "cc";
                }
                else if(noteAvg >= 65 && noteAvg < 85)
                {
                    return "bb";
                } else if(noteAvg >85 && noteAvg < 100)
                {
                    return "aa";
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public static Student parse(String line)
        {
            String[] columns = line.Split(',');
            int number = int.Parse(columns[0]);
            double visaNote = double.Parse(columns[1]);
            double finalNote = double.Parse(columns[2]);
            return new Student
            {
                Number = number,
                VisaNote = visaNote,
                FinalNote = finalNote
            };
        }

    }
}
