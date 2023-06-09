using System.Reflection;

namespace FluentValidationDemo.ValidationStaff
{
    public class PropertyRule<T, TProperty> where TProperty : IComparable<TProperty>
    {
        private Func<T, TProperty> func;
        private readonly T _validateModel;
        private List<ErrorMessage> validRules;
        private readonly MemberInfo _memberInfo;

        public PropertyRule(Func<T, TProperty> f, T model, List<ErrorMessage> container, MemberInfo memberInfo)
        {
            func = f;
            _validateModel = model;
            validRules = container;
            _memberInfo = memberInfo;
        }

        public ErrorMessage LessThat(TProperty property)
        {
            var result = func(_validateModel).CompareTo(property) < 0;
            var obj = new ErrorMessage(result, $"{_memberInfo.Name} greatest that {property}");
            validRules.Add(obj);

            return obj;
        }


        public ErrorMessage GreatestThat(TProperty property)
        {
            var result = func(_validateModel).CompareTo(property) > 0;
            var obj = new ErrorMessage(result, $"{_memberInfo.Name} less that {property}");
            validRules.Add(obj);

            return obj;
        }

        public ErrorMessage Equals(TProperty property)
        {
            var result = func(_validateModel).CompareTo(property) == 0;
            var obj = new ErrorMessage(result, $"{_memberInfo.Name} not equals {property}");
            validRules.Add(obj);

            return obj;
        }

        public ErrorMessage Must(Predicate<TProperty> mustPredicate)
        {
            var result = mustPredicate(func(_validateModel));
            var obj = new ErrorMessage(result, $"condition not met for {_memberInfo.Name}");
            validRules.Add(obj);

            return obj;
        }
    }
}
