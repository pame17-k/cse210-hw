namespace EternalQuest
{
    class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus)
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = 0;
        }

        public override int RecordEvent()
        {
            _amountCompleted++;
            if (_amountCompleted == _target)
            {
                return Points + _bonus;
            }
            return Points;
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {ShortName} ({Description}) -- Completed {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"Checklist Goal: {ShortName}, {Description}, {Points}, {_target}, {_bonus}, {_amountCompleted}";
        }
    }
}