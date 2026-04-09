using System;

namespace EternalQuest
{
    abstract class Goal
    {
        private string _shortName;
        private string _description;
        private int _points;

        public Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public string ShortName { get { return _shortName; } }
        public string Description { get {return _description; } }
        public int Points { get { return _points; } }

        public abstract int RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetStringRepresentation();

        public virtual string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_shortName} ({_description})";
        }
    }
}