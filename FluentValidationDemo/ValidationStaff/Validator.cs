using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;

namespace FluentValidationDemo.ValidationStaff
{
    public class Validator<T> where T : class
    {
        private readonly T _validateModel;
        private List<ErrorMessage> validateRule = new List<ErrorMessage>();

        public Validator(T model)
        {
            _validateModel = model;
        }

        public PropertyRule<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression) where TProperty : IComparable<TProperty>
        {

            return new PropertyRule<T, TProperty>(x => expression.Compile()(x), _validateModel, validateRule, expression.GetMemberAccess());
        }

        public string AllRulesSucceed()
        {

            return String.Join("\n", validateRule.Where(x=>!x.RuleSucceed).Select(x => x.Message));
        }
    }
}
